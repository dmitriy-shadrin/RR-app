using RR_app.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.BL.Factories.Abstractions
{
    public interface IGameFactory
    {
        IGame CreateGame(IRoom room);
        IPlayer CreatePlayer(IUser user);
    }
}
