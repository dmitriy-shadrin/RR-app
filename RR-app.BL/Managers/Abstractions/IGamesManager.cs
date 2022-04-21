using RR_app.BL.Factories.Abstractions;
using RR_app.Domain.Abstractions;

namespace RR_app.BL.Managers.Abstractions
{
    public interface IGamesManager
    {
        IGame CreateNewGame(IGameFactory gameFactory, IRoom room);
        IGame GetGameById(Guid id);
        void AddPlayerToGame(IGameFactory factory, Guid gameId, IUser user);
        void DeleteGame(Guid gameId);
    }
}
