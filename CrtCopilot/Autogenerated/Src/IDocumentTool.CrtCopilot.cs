namespace Creatio.Copilot
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Core;

	#region Interface: IDocumentTool

	/// <summary>
	/// Tool for working with documents for Creatio.AI.
	/// </summary>
	public interface IDocumentTool
	{

		#region Methods: Public

		/// <summary>
		/// Retrieves a list of <see cref="CopilotMessage"/> objects representing metadata about documents
		/// associated with the current session or intent for completion purposes.
		/// </summary>
		/// <param name="documents">The collection of <see cref="CreatioAIDocument"/> objects to process.</param>
		/// <returns>
		/// A list of <see cref="CopilotMessage"/> objects containing metadata about the documents.
		/// If no documents are associated, an empty list is returned.
		/// </returns>
		/// <remarks>
		/// - The method generates system messages with metadata about session-based or intent-based documents.
		/// - The metadata format includes details such as SessionId, IntentUId, FileId, and FileName.
		/// - A system prompt is added to guide the handling of document metadata.
		/// </remarks>
		IEnumerable<CopilotMessage> GetDocumentMessagesForCompletion(IEnumerable<ICreatioAIDocument> documents);

		/// <summary>
		/// Removes all documents from the <see cref="CopilotSession.Documents"/> collection that are not associated with a session.
		/// </summary>
		/// <param name="session">The <see cref="CopilotSession"/> instance from which documents will be removed.</param>
		/// <remarks>
		/// This method filters the documents where the <seeCreatCreatioAIDocumentle.SessionId"/> is not set
		/// and removes them from the <see cref="CopilotSession.Documents"/> collection.
		/// </remarks>
		void RemoveIntentDocumentsFromSession(CopilotSession session);

		/// <summary>
		/// Retrieves a list of document file locators based on the provided intent and root identifiers.
		/// </summary>
		/// <param name="userConnection">The <see cref="UserConnection"/> instance representing the current user connection.</param>
		/// <param name="currentIntentId">The unique identifier of the current intent.</param>
		/// <param name="rootIntentId">The unique identifier of the root intent.</param>
		/// <returns>
		/// A list of <see cref="CreatioAIDocument"/> objects containing information about the documents
		/// associated with the specified intent or root identifiers.
		/// </returns>
		IList<CreatioAIDocument> GetDocuments(UserConnection userConnection, Guid? currentIntentId,
			Guid? rootIntentId);

		/// <summary>
		/// Populates the session with documents associated with the current or root intent.
		/// </summary>
		/// <param name="userConnection">The <see cref="UserConnection"/> instance representing the current user connection.</param>
		/// <param name="session">The <see cref="CopilotSession"/> instance to populate with documents.</param>
		/// <remarks>
		/// This method retrieves documents linked to the current or root intent and adds them to the session.
		/// </remarks>
		void LoadSessionDocuments(UserConnection userConnection, CopilotSession session);

		#endregion

	}

	#endregion

}

