using PlaneProject.Models;

namespace PlaneProject.Services
{
    public interface IGameService
    {
        void RegisterPlayer(string connectionId, Guid playerId);
        (string ConnectionId1, string ConnectionId2, Guid GameId) AddWaitingPlayerIntoQueue(string connectionId);
        (string ConnectionId1, string ConnectionId2, bool IsPlayer1Turn) SetPlanes(List<PlanePart> planes, string gameId, string connectionId);
        (List<PlanePart> HitResult, string ConnectionId1, string ConnectionId2, bool IsPlayer1Turn) CheckIfHit(PlanePart planePart, string gameId, string connectionId);
    }
}
