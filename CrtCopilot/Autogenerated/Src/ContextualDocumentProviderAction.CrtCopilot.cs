namespace Creatio.Copilot
{
	using System;
	using System.Text;
	using Common.Logging;
	using Creatio.Copilot.Actions;
	using Terrasoft.Common;
	using Terrasoft.Core.Factories;
	using Terrasoft.File;
	using Terrasoft.File.Abstractions.TextExtraction;

	#region Class: ContextualDocumentProviderAction

	/// <summary>
	/// Contextual document provider code action.
	/// </summary>
	public class ContextualDocumentProviderAction : BaseExecutableCodeAction
	{

		#region Constants: Private

		private const string CaptionValue = "Get documents content.";
		private const string DescriptionValue = "Provides content of the available documents.";
		private const string FileNameMarkerFormatValue = "#FileName: {0}";
		private const string ContentMarkerValue = "#Content:";
		private const string ContentMarkerErrorValue = "#Content: Error retrieving document content.";
		private const string SessionNotFoundErrorMessage = "Session not found";

		#endregion

		#region Constructors: Internal

		/// <summary>
		/// Initializes a new instance of the <see cref="ContextualDocumentProviderAction"/> class.
		/// </summary>
		/// <param name="logger">An instance of the <see cref="ILog"/> implementing type to initialize the current
		/// instance with.</param>
		internal ContextualDocumentProviderAction(ILog logger): this() {
			_logger = logger;
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="ContextualDocumentProviderAction"/> class.
		/// </summary>
		public ContextualDocumentProviderAction() {
		}

		#endregion

		#region Properties: Private

		private ILog _logger;
		private ILog Logger => _logger ?? (_logger = LogManager.GetLogger(nameof(ContextualDocumentProviderAction)));

		#endregion

		#region Methods: Private

		private void RenderDocument(StringBuilder contentBuilder, CreatioAIDocument document,
				ITextContentExtractor contentExtractor) {
			contentBuilder.AppendFormat(FileNameMarkerFormatValue, document.FileName);
			contentBuilder.AppendLine();
			var entityFileLocator = new EntityFileLocator(document.FileSchemaName, document.FileId);
			try {
				string content = contentExtractor.ExtractText(entityFileLocator);
				contentBuilder.AppendLine(ContentMarkerValue);
				contentBuilder.AppendLine(content);
			} catch (Exception e) {
				Logger.Error($"Error retrieving document content for {document.FileName}", e);
				contentBuilder.AppendLine(ContentMarkerErrorValue);
			}
			contentBuilder.AppendLine();
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override LocalizableString GetCaption() {
			return new LocalizableString(CaptionValue);
		}

		/// <inheritdoc />
		public override LocalizableString GetDescription() {
			return new LocalizableString(DescriptionValue);
		}

		/// <inheritdoc />
		public override CopilotActionExecutionResult Execute(ActionExecutionOptions options) {
			var sessionManager = ClassFactory.Get<ICopilotSessionManager>();
			CopilotSession session = sessionManager.FindById(options.CopilotSessionUId);
			if (session == null) {
				Logger.Error($"Session {options.CopilotSessionUId} not found.");
				return new CopilotActionExecutionResult {
					Status = CopilotActionExecutionStatus.Failed,
					ErrorMessage = SessionNotFoundErrorMessage
				};
			}
			var contentExtractor = ClassFactory.Get<ITextContentExtractor>();
			var contentBuilder = new StringBuilder();
			foreach (CreatioAIDocument document in session.Documents) {
				RenderDocument(contentBuilder, document, contentExtractor);
			}
			return new CopilotActionExecutionResult {
				Status = CopilotActionExecutionStatus.Completed,
				Response = contentBuilder.ToString(),
				ResponseOptions = new ActionResponseOptions {
					TruncateContentOnSave = true
				}
			};
		}

		#endregion

	}

	#endregion

}
