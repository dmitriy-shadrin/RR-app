using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.BL.Exceptions
{
    public class GameIsFullException : RoomException
    {
        public GameIsFullException()
            : base("Game is full") { }
    }
}
