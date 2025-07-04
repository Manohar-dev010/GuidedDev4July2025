namespace Creatio.Copilot
{
	using System.Threading;
	using System.Threading.Tasks;
	using Creatio.Copilot;

	public interface ICopilotSessionResponseHandler
	{
		Task<bool> CanHandleAsync(CopilotSession session, CancellationToken cancellationToken = default);
		Task HandleAsync(CopilotSession session, CancellationToken cancellationToken = default);
	}
}

