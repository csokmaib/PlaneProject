using PlaneProject.Models;

namespace PlaneProject.Services
{
    public interface IGameService
    {
        void RegisterPlayer(string connectionId, Guid playerId);
        (string ConnectionId1, string ConnectionId2, Guid GameId) AddWaitingPlayerIntoQueue(string connectionId);
        bool SetPlanes(List<PlanePart> planes, string gameId, string connectionId);
    }
}
