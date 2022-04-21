using RR_app.DAL;
using RR_app.Domain;
using RR_app.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.Repository
{
    public class GameResultRepository : RepositoryBase<GameResult>, IGameResultRepository
    {
        public GameResultRepository(DBContext context)
            : base(context) { }
    }
}
