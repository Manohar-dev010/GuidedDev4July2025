namespace Creatio.Copilot
{
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using System.Security;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Web.SessionState;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;
	using Terrasoft.Web.Http.Abstractions;

	#region Class: CopilotIntentCallResultDto

	[DataContract]
	public class CopilotIntentCallResultDto
	{

		#region Properties: Public

		/// <summary>
		/// Status of the intent call.
		/// </summary>
		[DataMember(Name = "status")]
		public string Status { get; set; }

		/// <summary>
		/// Content produced by Copilot.
		/// </summary>
		[DataMember(Name = "content")]
		public string Content { get; set; }

		/// <summary>
		/// Message of the error if it occured. Null otherwise.
		/// </summary>
		[DataMember(Name = "errorMessage")]
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Warnings produced during intent call.
		/// </summary>
		[DataMember(Name = "warnings")]
		public IList<string> Warnings { get; set; }

		/// <summary>
		/// Result parameters returned from Copilot API. Should be specified as part of intent.
		/// </summary>
		[DataMember(Name = "resultParameters")]
		public IDictionary<string, object> ResultParameters { get; set; }

		/// <summary>
		/// Gets a value indicating whether the intent call was executed successfully.
		/// </summary>
		/// <value>
		/// <c>true</c> if the status of the intent call is <see cref="Creatio.Copilot.IntentCallStatus.ExecutedSuccessfully"/>;
		/// otherwise, <c>false</c>.
		/// </value>
		[DataMember(Name = "isSuccess")]
		public bool IsSuccess { get; set; }

		#endregion

	}

	#endregion

	#region Class: LegasyCopilotContextDto

	[Serializable]
	[DataContract]
	public class LegacyCopilotContextDto
	{

		#region Properties: Public

		[DataMember(Name = "parts")]
		public List<CreatioPageContextPart> Parts { get; private set; } = new List<CreatioPageContextPart>();

		#endregion

	}

	#endregion

	[DataContract]
	public class CopilotSendUserMessageResultDto : CopilotChatPart
	{

		#region Constructors: Public

		public CopilotSendUserMessageResultDto(CopilotChatPart copilotChatPart) {
			Messages = copilotChatPart.Messages;
			CopilotSession = new BaseCopilotSession(copilotChatPart.CopilotSession);
			ErrorCode = copilotChatPart.ErrorCode;
			ErrorMessage = copilotChatPart.ErrorMessage;
		}

		#endregion

	}

	#region Class: CopilotService

	[ServiceContract]
	[DefaultServiceRoute]
	[SspServiceRoute]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class CopilotService: BaseService, IReadOnlySessionState
	{

		#region Constants: Private

		private const string CanRunCopilotClientSideApiOperation = "CanRunCreatioAIClientSideApi";

		#endregion

		#region Methods: Private

		private CopilotContext ParseContext(string rawContextParts) {
			var result = new CopilotContext();
			foreach (JObject rawPart in (JArray)Json.Deserialize(rawContextParts)) {
				var typeName = (string)(JValue)rawPart.GetPropertyDefValue("type", (JValue)"CreatioPageContextPart");
				var type = BaseContextPart.GetKnownTypes().FirstOrDefault(x => x.Name == typeName);
				var part = (BaseContextPart)Json.Deserialize(Json.Serialize(rawPart), type);
				result.Parts.Add(part);
			}
			return result;
		}

		private CopilotSendUserMessageResultDto InternalSendUserMessage(string content, Guid? copilotSessionId,
				CopilotContext context = null, CopilotSendMessageOptions options = null) {
			ICopilotEngine copilotEngine = ClassFactory.Get<ICopilotEngine>();
			CopilotChatPart copilotChatPart = copilotEngine.SendUserMessage(content, copilotSessionId,
				context, options);
			return new CopilotSendUserMessageResultDto(copilotChatPart);
		}

		private ICopilotSessionManager GetSessionManager() {
			return ClassFactory.Get<ICopilotSessionManager>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sends message from the user to the Copilot.
		/// </summary>
		/// <param name="content">Content of the message.</param>
		/// <param name="copilotSessionId">Copilot session identifier. If empty, creates new session.</param>
		/// <param name="copilotContext">Context of the message.</param>
		/// <param name="options">Options of the message.</param>
		/// <returns><see cref="CopilotSendUserMessageResultDto"/>, the information of the conversation part.</returns>
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "copilotChatPart")]
		public CopilotSendUserMessageResultDto SendMessage(string content, Guid? copilotSessionId,
				string copilotContext = null, CopilotSendMessageOptions options = null) {
			var context = ParseContext(copilotContext);
			return InternalSendUserMessage(content, copilotSessionId, context, options);
		}

		/// <summary>
		/// Sends message from the user to the Copilot.
		/// </summary>
		/// <param name="content">Content of the message.</param>
		/// <param name="copilotSessionId">Copilot session identifier. If empty, creates new session.</param>
		/// <param name="copilotContext">Context of the message.</param>
		/// <returns><see cref="CopilotSendUserMessageResultDto"/>, the information of the conversation part.</returns>
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "copilotChatPart")]
		public CopilotSendUserMessageResultDto SendUserMessage(string content, Guid? copilotSessionId,
				LegacyCopilotContextDto copilotContext = null, CopilotSendMessageOptions options = null) {
			CopilotContext context = null;
			if (copilotContext != null) {
				context = new CopilotContext();
				context.Parts.AddRange(copilotContext.Parts);
			}
			return InternalSendUserMessage(content, copilotSessionId, context, options);
		}

		/// <summary>
		/// Returns all active Copilot session of the current user.
		/// </summary>
		/// <returns>List of the <see cref="CopilotSession"/> type instances.</returns>
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "copilotSessions")]
		public List<CopilotSession> GetActiveCopilotSessions() {
			ICopilotSessionManager copilotSessionManager = GetSessionManager();
			return copilotSessionManager.GetActiveSessions(UserConnection.CurrentUser.Id)?.ToList();
		}

		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "copilotMessages")]
		public List<CopilotMessage> GetCopilotSessionMessage(Guid copilotSessionId) {
			ICopilotSessionManager copilotSessionManager = GetSessionManager();
			CopilotSession copilotSession = copilotSessionManager.FindById(copilotSessionId);
			return copilotSession?.Messages?.OrderBy(message => message.CreatedOnTicks).ToList();
		}

		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CloseSession(Guid copilotSessionId) {
			ICopilotSessionManager copilotSessionManager = GetSessionManager();
			CopilotSession copilotSession = copilotSessionManager.FindById(copilotSessionId);
			if (copilotSession == null) {
				return;
			}
			copilotSessionManager.CloseSession(copilotSession, null);
		}

		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public async Task<CopilotIntentCallResultDto> ExecuteIntent(CopilotIntentCall data) {
			try {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation(CanRunCopilotClientSideApiOperation);
			} catch (SecurityException e) {
				return new CopilotIntentCallResultDto {
					Status = IntentCallStatus.InsufficientPermissions.ToString(),
					ErrorMessage = e.GetFullMessage()
				};
			} catch (Exception e) {
				return new CopilotIntentCallResultDto {
					Status = IntentCallStatus.FailedToExecute.ToString(),
					ErrorMessage = e.GetFullMessage()
				};
			}
			ICopilotEngine copilotEngine = ClassFactory.Get<ICopilotEngine>();
			HttpContext httpContext = HttpContextAccessor.GetInstance();
			CancellationToken token = httpContext.Response.ClientDisconnectedToken;
			CopilotIntentCallResult result = await copilotEngine.ExecuteIntentAsync(data, token);
			return new CopilotIntentCallResultDto {
				Status = result.Status.ToString(),
				Content = result.Content,
				Warnings = result.Warnings,
				ErrorMessage = result.ErrorMessage,
				IsSuccess = result.IsSuccess,
				ResultParameters = result.ResultParameters
			};
		}

		[WebInvoke(Method = "POST", UriTemplate = "getAvailableIntents/?mode={copilotIntentMode}",
			BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json,
			ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "availableIntentNames")]
		public IList<string> GetAvailableIntents(string[] names, string copilotIntentMode) {
			if (!Enum.TryParse(copilotIntentMode, true, out CopilotIntentMode usageMode)) {
				usageMode = CopilotIntentMode.Api;
			}
			if (usageMode == CopilotIntentMode.Api &&
				!UserConnection.DBSecurityEngine.GetCanExecuteOperation(CanRunCopilotClientSideApiOperation)) {
				return new List<string>();
			}
			ICopilotEngine copilotEngine = ClassFactory.Get<ICopilotEngine>();
			return copilotEngine.GetAvailableSkills(usageMode, names);
		}

		[OperationContract]
		[WebGet(UriTemplate = "GetActiveSessionsWithPreview",
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		public List<CopilotActiveSessionDto> GetActiveSessionsWithPreview() {
			var args = new ConstructorArgument("userConnection", UserConnection);
			ICopilotSessionRepository copilotSessionRepository = ClassFactory.Get<ICopilotSessionRepository>(args);
			return copilotSessionRepository.GetActiveSessionsWithPreview(UserConnection.CurrentUser.Id);
		}

		[OperationContract]
		[WebGet(UriTemplate = "GetSessionsPageWithPreview/{offset}/{count}",
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		public List<CopilotActiveSessionDto> GetSessionsPageWithPreview(string offset, string count) {
			if (int.TryParse(offset, out int offsetValue) && int.TryParse(count, out int countValue)) {
				var args = new ConstructorArgument("userConnection", UserConnection);
				ICopilotSessionRepository copilotSessionRepository = ClassFactory.Get<ICopilotSessionRepository>(args);
				return copilotSessionRepository.GetActiveSessionsWithPreview(
					UserConnection.CurrentUser.Id, offsetValue, countValue);
			}

			return new List<CopilotActiveSessionDto>();
		}

		[OperationContract]
		[WebGet(UriTemplate = "GetActiveSessionPreviewById/{sessionId}",
			ResponseFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		public CopilotActiveSessionDto GetActiveSessionPreviewById(string sessionId) {
			if (Guid.TryParse(sessionId, out var sessionIdValue)) {
				var args = new ConstructorArgument("userConnection", UserConnection);
				ICopilotSessionRepository copilotSessionRepository = ClassFactory.Get<ICopilotSessionRepository>(args);
				return copilotSessionRepository.GetActiveSessionPreviewById(UserConnection.CurrentUser.Id, sessionIdValue);
			}

			return null;
		}

		#endregion

	}

	#endregion



}
