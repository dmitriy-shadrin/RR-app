using Microsoft.AspNetCore.SignalR;
using RR_app.BL.Exceptions;
using RR_app.BL.Factories;
using RR_app.BL.Factories.Abstractions;
using RR_app.BL.Managers.Abstractions;
using RR_app.Domain;
using RR_app.Domain.Abstractions;
using RR_app.Domain.Events;
using RR_app.Server.DTO;

namespace RR_app.Server.Hubs
{
    public class RoomHub : Hub
    {

        private readonly IRoomsManager _roomManager;
        private readonly IGamesManager _gamesManager;
        private readonly IGameFactory _gameFactory;

        public RoomHub(IRoomsManager roomManager, IGamesManager gamesManager, IGameFactory gameFactory)
        {
            _roomManager = roomManager;
            _gamesManager = gamesManager;
            _gameFactory = gameFactory;
        }

        /// <summary>
        /// Create new lobby
        /// </summary>
        /// <returns></returns>
        public async Task Create()
        {
            var newRoomId = _roomManager.CreateRoom().Id;
            await Clients.Caller.SendAsync("RoomCreatedHost", newRoomId);
            await Clients.All.SendAsync("RoomCreated", newRoomId);
        }

        /// <summary>
        /// Connect to exisiting lobby
        /// </summary>
        /// <param name="connectRequest">Room connect request payload</param>
        /// <returns></returns>
        public async Task Connect(RoomConnectRequest connectRequest)
        {
            var groupName = connectRequest.RoomId.ToString();

            var user = new User { Id = Context.ConnectionId, Name = connectRequest.UserName };
            
            try
            {
                _roomManager.ConnectUserToRoom(connectRequest.RoomId, user);
            }
            catch (RoomException e)
            {
                await Clients.Caller.SendAsync("Error", e.Message);
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("ConnectedToRoom", connectRequest.RoomId);
            var room = _roomManager.GetRoomById(connectRequest.RoomId);
            if (room.GetUsersCount() == 2)
            {                
                var game = _gamesManager.CreateNewGame(_gameFactory, room);
                var createdGameInfo = new GameConnectRequest(game.Id, room.Id, user.Name);
                await Clients.Group(groupName).SendAsync("GameCreated", createdGameInfo);
            }
        }
    }
}
