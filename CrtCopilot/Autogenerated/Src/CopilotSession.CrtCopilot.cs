namespace Creatio.Copilot
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using Terrasoft.Common;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion;

	#region Class: CopilotSession

	/// <summary>
	/// Represents a session of the Copilot.
	/// </summary>
	[DataContract]
	[Serializable]
	[KnownType(typeof(CreatioAIDocument))]
	public class CopilotSession : BaseCopilotSession
	{

		#region Constructors: Public

		static CopilotSession() {
			DerivedTypes.Add(typeof(CopilotSession));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CopilotSession"/> class.
		/// </summary>
		public CopilotSession() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CopilotSession"/> class with the specified user ID and intent ID.
		/// </summary>
		/// <param name="userId">The unique identifier of the user.</param>
		/// <param name="intentId">The unique identifier of the intent, or null if not specified.</param>
		public CopilotSession(Guid userId, Guid? intentId)
			: base(userId, intentId) {
		}

		public CopilotSession(Guid userId, List<CopilotMessage> messages, Guid? intentId) : this(userId, intentId) {
			messages.CheckArgumentNull(nameof(messages));
			AddMessages(messages);
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Current context of the Copilot session.
		/// </summary>
		[DataMember(Name = "currentContext")]
		public CopilotContext CurrentContext { get; internal set; }

		/// <summary>
		/// The list of Copilot session messages.
		/// </summary>
		private List<CopilotMessage> _messages = new List<CopilotMessage>();
		[DataMember(Name = "messages")]
		public IEnumerable<CopilotMessage> Messages => _messages;

		/// <summary>
		/// Indicates that the session is transient and does not support continuation of execution.
		/// </summary>
		[DataMember(Name = "isTransient")]
		public bool IsTransient { get; set; }

		/// <summary>
		/// Gets or sets the list of documents associated with the given session.
		/// </summary>
		[DataMember(Name = "documents")]
		public IList<ICreatioAIDocument> Documents { get; set; } = new List<ICreatioAIDocument>();

		/// <summary>
		/// The date and time when the session was loaded last time.
		/// </summary>
		[DataMember(Name = "loadedOn")]
		public DateTime? LoadedOn { get; set; }

		#endregion

		#region Methods: Public

		public CopilotSession AddMessage(CopilotMessage copilotMessage) {
			copilotMessage.IntentId = CurrentIntentId;
			copilotMessage.RootIntentId = RootIntentId;
			_messages.Add(copilotMessage);
			return this;
		}

		public CopilotSession AddMessages(IEnumerable<CopilotMessage> copilotMessages) {
			copilotMessages.ForEach(message => {
				message.IntentId = CurrentIntentId;
				message.RootIntentId = RootIntentId;
			});
			_messages.AddRange(copilotMessages);
			return this;
		}

		public CopilotMessage RemoveLastUserMessage() {
			var lastUserMessage = _messages.FindLast(message => message.Role == CopilotMessageRole.User);
			if (lastUserMessage != null) {
				_messages.Remove(lastUserMessage);
			}
			return lastUserMessage;
		}

		public List<CopilotMessage> CreateToolCallMessages(string toolCallId, string resultContent) {
			var resultMessages = new List<CopilotMessage>();
			Guid? toolRequestMessageId = null;
			Guid? toolResponseMessageId = null;
			lock (Messages) {
				CopilotMessage oldCallRequestMessage = Messages.FirstOrDefault(msg =>
					msg.ToolCalls.Any(call => call.Id == toolCallId) && msg.Role == CopilotMessageRole.Assistant);
				if (oldCallRequestMessage == null) {
					return resultMessages;
				}
				ToolCall toolCall = oldCallRequestMessage.ToolCalls.FirstOrDefault(call => call.Id == toolCallId);
				oldCallRequestMessage.ToolCalls.Remove(toolCall);
				if (oldCallRequestMessage.ToolCalls.Count == 0) {
					toolRequestMessageId = oldCallRequestMessage.Id;
					_messages.Remove(oldCallRequestMessage);
				}
				CopilotMessage oldCallResponseMessage = Messages.FirstOrDefault(msg =>
					msg.ToolCallId == toolCallId && msg.Role == CopilotMessageRole.Tool);
				if (oldCallResponseMessage != null) {
					toolResponseMessageId = oldCallResponseMessage.Id;
					_messages.Remove(oldCallResponseMessage);
				}
				CopilotMessage newCallRequestMessage = CopilotMessage.FromAssistant(toolCall);
				newCallRequestMessage.Id = toolRequestMessageId ?? newCallRequestMessage.Id; 
				CopilotMessage newCallResponseMessage = CopilotMessage.FromTool(resultContent, toolCallId);
				newCallResponseMessage.Id = toolResponseMessageId ?? newCallResponseMessage.Id;
				resultMessages.AddRange(new [] {
					newCallRequestMessage,
					newCallResponseMessage
				});
				return resultMessages;
			}
		}

		/// <summary>
		/// Set current intent for the Copilot session.
		/// </summary>
		/// <param name="intentId">New intent identifier.</param>
		public void SetCurrentIntent(Guid intentId) {
			if (CurrentIntentId == null) {
				RootIntentId = intentId;
			}
			CurrentIntentId = intentId;
			CopilotMessage lastUserMessage = _messages.FindLast(message => message.Role == CopilotMessageRole.User);
			if (lastUserMessage != null) {
				lastUserMessage.IntentId = intentId;
				lastUserMessage.IsSaved = false;
			}
		}

		#endregion

	}

	#endregion

}

