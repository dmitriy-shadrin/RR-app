using RR_app.DAL;
using RR_app.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DBContext _context;
        private IGameResultRepository _resultRepository;
        public IGameResultRepository GameResults
        {
            get
            {
                if (_resultRepository == null)
                    _resultRepository = new GameResultRepository(_context);
                return _resultRepository;
            }
        }

        public RepositoryWrapper(DBContext repositoryContext)
        {
            _context = repositoryContext;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
