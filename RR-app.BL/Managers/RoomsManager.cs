using RR_app.BL.Exceptions;
using RR_app.BL.Managers.Abstractions;
using RR_app.Domain;
using RR_app.Domain.Abstractions;

namespace RR_app.BL.Managers
{
    public class RoomsManager : IRoomsManager
    {
        private List<Room> _rooms = new List<Room>();

        public void ConnectUserToRoom(Guid roomId, IUser user)
        {
            var room = _rooms.FirstOrDefault(r => r.Id == roomId);

            if (room != null)
            {
                if (room.GetUsersCount() < 2)
                    room.Join(user);
                else
                    throw new RoomIsFullException();
            }
            else
                throw new RoomNotFoundException();
        }

        public IRoom CreateRoom()
        {
            var room = new Room();
            _rooms.Add(room);
            return room;
        }

        public void DeleteRoom(Guid roomId)
        {
            var room = _rooms.FirstOrDefault(r => r.Id == roomId);
            room?.Destroy();
            _rooms.Remove(room);
        }

        public IRoom GetRoomById(Guid roomId)
        {
            return _rooms.FirstOrDefault(r => r.Id == roomId);
        }
    }
}
