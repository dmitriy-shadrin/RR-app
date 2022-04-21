using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.BL.Exceptions
{
    public class RoomIsFullException : RoomException
    {
        public RoomIsFullException()
            : base("Room is full") { }
    }
}
