using RR_app.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.Domain
{
    public class RandomDamageGamePlayer : IPlayer
    {
        private int _healthPoints;
        private IUser _user;

        public IUser ParentUser => _user;

        public int HealthPoints => _healthPoints;

        public RandomDamageGamePlayer(IUser user)
        {
            _user = user;
            _healthPoints = 10;
        }        

        public void TakeDamage(int damage)
        {
            if (HealthPoints > 0)
                _healthPoints -= damage;
        }
    }
}
