using RR_app.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.Domain.Events
{
    public delegate void GameCompletedEventHandler(IGame sender, GameCompletedEventArgs args);
}
