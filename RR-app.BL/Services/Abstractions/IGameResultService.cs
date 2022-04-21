using RR_app.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.BL.Services.Abstractions
{
    public interface IGameResultService
    {
        void SaveGameResult(IGame game, IUser winner);
    }
}
