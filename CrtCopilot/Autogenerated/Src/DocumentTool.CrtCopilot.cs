namespace Creatio.Copilot
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;

	#region Class: DocumentTool

	/// <inheritdoc />
	[DefaultBinding(typeof(IDocumentTool))]
	public class DocumentTool : IDocumentTool
	{

		#region Constants: Private

		private const string FilePromptFormat =
			"There is a list of documents available for you.\nInstructions:\nIf the content of a document is " +
			"required to answer a user query, you must use action 'GetDocumentsContent' to retrieve the documents " +
			"content. Use the retrieved content to generate a response to the user query. If content starts with " +
			"[Truncated] marker, it means content needs to be retrieved again if it is required. List of available" +
			" documents: {0}";

		#endregion

		#region Methods: Private

		private IList<CreatioAIDocument> GetSessionDocuments(UserConnection userConnection, Guid sessionId) {
			var selectQuery = (Select)new Select(userConnection)
					.Column("Id")
					.Column("Name")
				.From("CreatioAISessionFile").WithHints(Hints.NoLock)
				.Where("SessionId").IsEqual(Column.Parameter(sessionId));
			var result = new List<CreatioAIDocument>();
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var reader = selectQuery.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid id = reader.GetColumnValue<Guid>("Id");
						string fileName = reader.GetColumnValue<string>("Name");
						var locator = new CreatioAIDocument {
							FileId = id,
							FileName = fileName,
							SessionId = sessionId,
							FileSchemaName = "CreatioAISessionFile"
						};
						result.Add(locator);
					}
				}
			}
			return result;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public IEnumerable<CopilotMessage> GetDocumentMessagesForCompletion(
				IEnumerable<ICreatioAIDocument> documents) {
			documents = documents == null ? Array.Empty<CreatioAIDocument>() : documents.ToArray();
			if (!documents.Any()) {
				yield break;
			}
			string filePrompt = string.Format(FilePromptFormat, string.Join(", ", documents.Select(
				doc => doc.FileName)));
			yield return new CopilotMessage(filePrompt, CopilotMessageRole.System);
		}

		/// <inheritdoc />
		public void RemoveIntentDocumentsFromSession(CopilotSession session) {
			if (session.Documents.IsEmpty()) {
				return;
			}
			List<ICreatioAIDocument> documentsToRemove = session.Documents
				.Where(doc => !doc.SessionId.HasValue).ToList();
			foreach (ICreatioAIDocument document in documentsToRemove) {
				session.Documents.Remove(document);
			}
		}

		/// <inheritdoc />
		public IList<CreatioAIDocument> GetDocuments(UserConnection userConnection, Guid? currentIntentId,
				Guid? rootIntentId) {
			var selectQuery = (Select)new Select(userConnection).Column("Id").Column("Name").Column("IntentUId")
				.From("CreatioAIIntentFile").WithHints(Hints.NoLock).Where("IntentUId")
				.In(Column.Parameters(currentIntentId ?? Guid.Empty, rootIntentId ?? Guid.Empty));
			var result = new List<CreatioAIDocument>();
			using (var dbExecutor = userConnection.EnsureDBConnection()) {
				using (var reader = selectQuery.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid id = reader.GetColumnValue<Guid>("Id");
						string fileName = reader.GetColumnValue<string>("Name");
						string actualIntentId = reader.GetColumnValue<string>("IntentUId");
						var locator = new CreatioAIDocument {
							FileId = id,
							FileName = fileName,
							IntentId = Guid.Parse(actualIntentId),
							FileSchemaName = "CreatioAIIntentFile"
						};
						result.Add(locator);
					}
				}
			}
			return result;
		}

		/// <inheritdoc />
		public void LoadSessionDocuments(UserConnection userConnection, CopilotSession session) {
			IList<CreatioAIDocument> documents = GetSessionDocuments(userConnection, session.Id);
			if (documents.IsNotNullOrEmpty()) {
				session.Documents.AddRange(documents);
			}
		}

		#endregion

	}

	#endregion

}

