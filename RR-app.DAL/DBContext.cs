using Microsoft.EntityFrameworkCore;
using RR_app.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.DAL
{
    public class DBContext : DbContext
    {
        DbSet<GameResult> GameResults { get; set; }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }
    }
}
