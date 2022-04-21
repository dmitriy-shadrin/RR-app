using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.Repository.Abstractions
{
    public interface IRepositoryWrapper
    {
        IGameResultRepository GameResults { get; }
        void Save();
    }
}
