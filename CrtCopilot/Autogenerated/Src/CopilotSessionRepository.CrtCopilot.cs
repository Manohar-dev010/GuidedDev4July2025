namespace Creatio.Copilot
{
	using System;
	using System.Linq;
	using System.Data;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Terrasoft.Configuration;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;

	#region Interface: ICopilotSessionRepository

	public interface ICopilotSessionRepository
	{

		#region Methods: Public

		/// <summary>
		/// Returns all active Copilot sessions of the current user with preview data.
		/// </summary>
		/// <param name="userId">User identifier for filtering sessions.</param>
		/// <param name="offset">Offset for sessions pagination.</param>
		/// <param name="count">Count of rows for sessions pagination.</param>
		/// <returns>List of active sessions.</returns>
		List<CopilotActiveSessionDto> GetActiveSessionsWithPreview(Guid userId, int offset, int count);

		/// <summary>
		/// Returns all active Copilot sessions of the current user with preview data.
		/// </summary>
		/// <param name="userId">User identifier for filtering sessions.</param>
		/// <returns>List of active sessions.</returns>
		List<CopilotActiveSessionDto> GetActiveSessionsWithPreview(Guid userId);

		/// <summary>
		/// Returns active Copilot session of the current user with preview data by id.
		/// </summary>
		/// <param name="userId">User identifier for filtering sessions.</param>
		/// <param name="sessionId">Session identifier.</param>
		/// <returns>Active session by id.</returns>
		CopilotActiveSessionDto GetActiveSessionPreviewById(Guid userId, Guid sessionId);

		#endregion

	}

	#endregion

	#region Class: CopilotIntentAuthor

	[DataContract]
	public class CopilotIntentAuthor
	{

		#region Properties: Public

		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "name")]
		public string Name {
			get; set;
		}

		[DataMember(Name = "caption")]
		public string Caption {
			get; set;
		}

		#endregion

	}

	#endregion

	#region Class: CopilotActiveSessionDto

	[DataContract]
	public class CopilotActiveSessionDto
	{

		#region Properties: Public

		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "date")]
		public string Date {
			get; set;
		}

		[DataMember(Name = "author")]
		public CopilotIntentAuthor Author {
			get; set;
		}

		[DataMember(Name = "caption")]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "preview")]
		public string Preview {
			get; set;
		}

		#endregion

	}

	#endregion

	#region Class: CopilotSessionRepository

	/// <summary>
	/// Provides methods for accessing active Copilot sessions from the database.
	/// </summary>
	[DefaultBinding(typeof(ICopilotSessionRepository))]
	public class CopilotSessionRepository : ICopilotSessionRepository
	{

		#region Constants: Private

		private const string DateFormat = "yyyy'-'MM'-'ddTHH':'mm':'ss";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="CopilotSessionRepository"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection used for database operations.</param>
		public CopilotSessionRepository(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		private ICopilotSessionManager _copilotSessionManager;
		protected ICopilotSessionManager CopilotSessionManager {
			get {
				return _copilotSessionManager = _copilotSessionManager ?? ClassFactory.Get<ICopilotSessionManager>();
			}
		}

		#endregion

		#region Methods: Private

		private Select CreateSessionSelectQuery(Guid userId, Guid? sessionId = null) {
			var select = (Select)new Select(_userConnection)
					.Column("CSE", "Id").As("Id")
					.Column("CSE", "RootIntentId").As("IntentId")
					.Column("SS", "Name").As("IntentName")
					.Column("SS", "Caption").As("IntentCaption")
					.Column("CSE", "Title").As("Caption")
					.Column("CSE", "LastMessageContent").As("LastMessageContent")
					.Column("CSE", "LastMessageDate").As("LastMessageDate")
					.Column("CSE", "ModifiedOn").As("ModifiedOn")
				.From("VwCopilotSessionEx").WithHints(Hints.NoLock).As("CSE")
				.LeftOuterJoin("SysSchema").As("SS")
					.On("CSE", "RootIntentId").IsEqual("SS", "UId")
				.Where("CSE", "StateId").IsEqual(Column.Parameter(CopilotSessionState.Active))
					.And("CSE", "UserId").IsEqual(Column.Parameter(userId));
			if (sessionId.HasValue) {
				select.And("CSE", "Id").IsEqual(Column.Parameter(sessionId.Value));
			}
			return select.OrderByDesc("CSE", "LastMessageDate") as Select;
		}

		private string FormatDateString(DateTime date) {
			return TimeZoneInfo
				.ConvertTime(date, TimeZoneInfo.Utc, _userConnection.CurrentUser.TimeZone)
				.ToString(DateFormat);
		}

		private CopilotActiveSessionDto MapReaderToSession(IDataReader reader) {
			var session = new CopilotActiveSessionDto {
				Id = reader.GetColumnValue<Guid>("Id"),
				Caption = reader.GetColumnValue<string>("Caption"),
				Date = FormatDateString(reader.GetColumnValue<DateTime>("ModifiedOn")),
				Author = new CopilotIntentAuthor {
					Id = reader.GetColumnValue<Guid>("IntentId"),
					Name = reader.GetColumnValue<string>("IntentName"),
					Caption = reader.GetColumnValue<string>("IntentCaption")
				}
			};
			string lastMessageContent = reader.GetColumnValue<string>("LastMessageContent");
			var lastMessageDate = (DateTime?)reader.GetColumnValue("LastMessageDate");
			if (lastMessageContent.IsNullOrEmpty() && !TryGetLiveLastMessageValues(session, 
					out lastMessageContent, out lastMessageDate)) {
				return session;
			}
			session.Preview = lastMessageContent;
			if (lastMessageDate == null) {
				return session;
			}
			session.Date = FormatDateString(lastMessageDate.Value);
			return session;
		}

		private bool TryGetLiveLastMessageValues(CopilotActiveSessionDto session, out string lastMessageContent,
				out DateTime? lastMessageDate) {
			lastMessageContent = null;
			lastMessageDate = null;
			CopilotSession liveSession = CopilotSessionManager.FindById(session.Id);
			if (liveSession == null) {
				return false;
			}
			CopilotSession copilotSession = CopilotSessionManager.FindById(session.Id);
			CopilotMessage lastMessage = copilotSession?.Messages?
				.Where(m => new[] { "assistant", "user" }.Contains(m.Role))
				.OrderByDescending(message => message.Date)
				.FirstOrDefault();
			if (lastMessage == null) {
				return false;
			}
			lastMessageContent = lastMessage.Content;
			lastMessageDate = lastMessage.Date;
			return true;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public List<CopilotActiveSessionDto> GetActiveSessionsWithPreview(Guid userId, int offset, int count) {
			return CreateSessionSelectQuery(userId)
				.OffsetFetch(offset, count)
				.ExecuteEnumerable(MapReaderToSession)
				.DistinctBy(s => s.Id)
				.ToList();
		}

		/// <inheritdoc />
		public List<CopilotActiveSessionDto> GetActiveSessionsWithPreview(Guid userId) {
			return CreateSessionSelectQuery(userId)
				.ExecuteEnumerable(MapReaderToSession)
				.DistinctBy(s => s.Id)
				.ToList();
		}

		/// <inheritdoc />
		public CopilotActiveSessionDto GetActiveSessionPreviewById(Guid userId, Guid sessionId) {
			CopilotActiveSessionDto session = CreateSessionSelectQuery(userId, sessionId)
				.ExecuteEnumerable(MapReaderToSession)
				.FirstOrDefault();
			return session;
		}

		#endregion

	}

	#endregion

}
