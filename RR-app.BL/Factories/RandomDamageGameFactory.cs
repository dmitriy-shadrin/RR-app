using RR_app.BL.Factories.Abstractions;
using RR_app.Domain;
using RR_app.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.BL.Factories
{
    public class RandomDamageGameFactory : IGameFactory
    {
        public IGame CreateGame(IRoom room)
        {
            var game = new RandomDamageGame();
            return game;
        }

        public IPlayer CreatePlayer(IUser user)
        {
            var player = new RandomDamageGamePlayer(user);
            return player;
        }
    }
}
