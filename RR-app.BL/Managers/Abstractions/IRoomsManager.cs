using RR_app.Domain.Abstractions;

namespace RR_app.BL.Managers.Abstractions
{
    public interface IRoomsManager
    {
        IRoom CreateRoom();
        IRoom GetRoomById(Guid roomId);
        void DeleteRoom(Guid roomId);
        void ConnectUserToRoom(Guid roomId, IUser user);
    }
}
