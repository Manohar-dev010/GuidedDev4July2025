namespace Creatio.Copilot
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using Terrasoft.Configuration.GenAI;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion.Requests;
	using SystemSettings = Terrasoft.Core.Configuration.SysSettings;

	[DefaultBinding(typeof(ICopilotSessionResponseHandler))]
	public class CopilotSessionTitleUpdater : ICopilotSessionResponseHandler
	{

		#region Constants: Private

		private const string PromptTemplate =
			"Generate a concise, specific conversation title (1-5 words, up to 40 characters). " +
			"Avoid personal names, greetings, or punctuation except normal words. \nIf the messages mention any domain objects (tables, entities, modules, etc.), " +
			"include their names in the topic." + "Output the topic text ONLY, without quotes or any extra text.";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly IGenAICompletionServiceProxy _completionService;
		private readonly ICopilotSessionManager _sessionManager;
		private readonly ICopilotMsgChannelSender _msgChannelSender;


		#endregion

		#region Constructors: Public

		public CopilotSessionTitleUpdater(UserConnection userConnection, IGenAICompletionServiceProxy completionService,
				ICopilotSessionManager sessionManager, ICopilotMsgChannelSender msgChannelSender) {
			_userConnection = userConnection;
			_completionService = completionService;
			_sessionManager = sessionManager;
			_msgChannelSender = msgChannelSender;
		}

		#endregion

		#region Methods: Private

		private static ChatMessage BuildPromptMessage() =>
			new ChatMessage {
				Role = CopilotMessageRole.System,
				Content = PromptTemplate
			};

		private static List<ChatMessage> BuildMessagesForRequest(CopilotSession session) {
			var promptMessage = BuildPromptMessage();
			var userMessages = session.Messages
				.Where(m => m.Role == CopilotMessageRole.User 
					|| m.Role == CopilotMessageRole.Assistant || m.Role == CopilotMessageRole.Tool)
				.Select(m => m.ToCompletionApiMessage());
			return new[] { promptMessage }.Concat(userMessages).ToList();
		}

		#endregion

		#region Methods: Public

		public Task<bool> CanHandleAsync(CopilotSession session, CancellationToken ct = default) {
			var userMessagesToCreateTitle =
				SystemSettings.GetValue(_userConnection, "CreatioAIUserMessagesToCreateTitle", 1);
			return Task.FromResult(
				string.IsNullOrEmpty(session.Title) &&
				session.Messages.Count(x => x.Role == CopilotMessageRole.User) >= userMessagesToCreateTitle); 
		}

		public async Task HandleAsync(CopilotSession session, CancellationToken cancellationToken = default) {
			var messages = BuildMessagesForRequest(session);
			var request = new ChatCompletionRequest {
				Messages = messages,
			};
			var response = await _completionService.ChatCompletionAsync(request, cancellationToken);
			session.Title = response.Choices.FirstOrDefault()?.Message.Content;
			_sessionManager.Update(session, null);
			_msgChannelSender.SendSessionProgress(CopilotSessionProgress.Create(_userConnection, session,
				CopilotSessionProgressStates.TitleUpdated, session.Title), _userConnection.CurrentUser.Id);
		}

		#endregion

	}
}

