using RR_app.BL.Services.Abstractions;
using RR_app.Domain;
using RR_app.Domain.Abstractions;
using RR_app.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.BL.Services
{
    public class GameResultService : IGameResultService
    {
        private readonly IRepositoryWrapper _repo;

        public GameResultService(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public void SaveGameResult(IGame game, IUser winner)
        {
            var result = new GameResult()
            {
                GameId = game.Id,
                WinnerName = winner.Name
            };
            _repo.GameResults.Create(result);
            _repo.Save();
        }
    }
}
