using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.BL.Exceptions
{
    public class RoomNotFoundException : RoomException
    {
        public RoomNotFoundException()
            : base("Room not found") { }
    }
}
