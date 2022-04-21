using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.Domain.Abstractions
{
    public interface IPlayer
    {
        IUser ParentUser { get; }
        int HealthPoints { get; }
        void TakeDamage(int damage);
    }
}
