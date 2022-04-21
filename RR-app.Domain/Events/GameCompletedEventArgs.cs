using RR_app.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.Domain.Events
{
    public class GameCompletedEventArgs : EventArgs
    {
        public IPlayer Winner { get; init; }

        public GameCompletedEventArgs(IPlayer winner)
        {
            Winner = winner;
        }
    }
}
