using RR_app.BL.Factories.Abstractions;
using RR_app.BL.Managers.Abstractions;
using RR_app.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.BL.Managers
{
    public class GamesManager : IGamesManager
    {
        private List<IGame> _games = new();

        public void AddPlayerToGame(IGameFactory factory, Guid gameId, IUser user)
        {
            var game = _games.FirstOrDefault(g => g.Id == gameId);
            if (game != null)
            {
                var player = factory.CreatePlayer(user);
                if (game.GetPlayersCount() < 2)
                    game.AddPlayer(player);
            }
        }

        public IGame CreateNewGame(IGameFactory gameFactory, IRoom room)
        {
            var game = gameFactory.CreateGame(room);
            _games.Add(game);
            return game;
        }

        public void DeleteGame(Guid gameId)
        {
            var gameToRemove = _games.FirstOrDefault(g => g.Id == gameId);
            
            if (gameToRemove != null)
                _games.Remove(gameToRemove);
        }

        public IGame GetGameById(Guid id)
        {
            return _games.FirstOrDefault(g => g.Id == id);
        }
    }
}
