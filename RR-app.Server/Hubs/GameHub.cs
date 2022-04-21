using Microsoft.AspNetCore.SignalR;
using RR_app.BL.Factories.Abstractions;
using RR_app.BL.Managers.Abstractions;
using RR_app.BL.Services.Abstractions;
using RR_app.Domain;
using RR_app.Server.DTO;

namespace RR_app.Server.Hubs
{
    public class GameHub : Hub
    {
        private readonly IGamesManager _gamesManager;
        private readonly IGameFactory _gameFactory;
        private readonly IRoomsManager _roomManager;
        private readonly IGameResultService _gameResultService;

        public GameHub(IGamesManager gamesManager, IGameFactory gameFactory, IRoomsManager roomsManager, IGameResultService gameResultService)
        {
            _gamesManager = gamesManager;
            _gameFactory = gameFactory;
            _roomManager = roomsManager;
            _gameResultService = gameResultService;
        }

        /// <summary>
        /// Connect co created game
        /// </summary>
        /// <param name="connectRequest">Data used to connect to game</param>
        /// <returns></returns>
        public async Task Connect(GameConnectRequest connectRequest)
        {
            var user = new User() { Id = Context.ConnectionId, Name = connectRequest.UserName };
            var game = _gamesManager.GetGameById(connectRequest.GameId);
            if (game != null)
            {
                var groupName = game.Id.ToString();
                _gamesManager.AddPlayerToGame(_gameFactory, game.Id, user);
                await Groups.AddToGroupAsync(user.Id, groupName);

                if (game.IsReadyToStart())
                {
                    game.GameStarted += async (game, gameStartedArgs) =>
                    {
                        await Clients.Group(groupName).SendAsync("GameStarted", gameStartedArgs.Players.Select(p => p.ParentUser));
                    };
                    game.GameCompleted += async (game, gameCompletedArgs) =>
                    {
                        await Clients.Group(groupName).SendAsync("GameCompleted", gameCompletedArgs.Winner.ParentUser.Name);
                        _gameResultService.SaveGameResult(game, gameCompletedArgs.Winner.ParentUser);
                        _gamesManager.DeleteGame(game.Id);
                        _roomManager.DeleteRoom(connectRequest.RoomId);

                    };

                    await game.StartAsync();
                }
            }
        }
    }
}
