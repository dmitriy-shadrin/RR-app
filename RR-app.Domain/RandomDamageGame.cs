using RR_app.Domain.Abstractions;
using RR_app.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.Domain
{
    public class RandomDamageGame : IGame, IDisposable
    {
        private PeriodicTimer _timer;
        private GameStateEnum _state;
        private List<IPlayer> _players;
        private Random _random;

        public event GameCompletedEventHandler GameCompleted;
        public event GameStartedEventHandler GameStarted;

        public Guid Id { get; init; }

        public IPlayer? Winner { get; private set; }
        public GameStateEnum State => _state;

        public void Dispose()
        {
            _timer?.Dispose();

            if (GameCompleted != null)
                foreach (var d in GameCompleted.GetInvocationList())
                    GameCompleted -= (d as GameCompletedEventHandler);

            if (GameStarted != null)
                foreach (var d in GameStarted.GetInvocationList())
                    GameStarted -= (d as GameStartedEventHandler);
        }

        public RandomDamageGame()
        {
            _players = new();
            _timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            _random = new Random();
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Stop game loop
        /// </summary>
        /// <returns></returns>
        public void End()
        {
            _state = GameStateEnum.Completed;
            GameCompleted?.Invoke(this, new GameCompletedEventArgs(Winner));
            Dispose();            
        }

        /// <summary>
        /// Start game loop
        /// </summary>
        /// <returns></returns>
        public async Task StartAsync()
        {
            _state = GameStateEnum.InProgress;
            while (await _timer.WaitForNextTickAsync())
            {
                PerformIteration();
            }
        }

        /// <summary>
        /// Perform one iteration of game loop
        /// </summary>
        /// <returns></returns>
        public void PerformIteration()
        {
            var losers = _players.Where(p => p.HealthPoints <= 0).ToList();

            if (losers.Count == 0) // No dead players, continue game
            {
                foreach (var player in _players)
                {
                    player.TakeDamage(_random.Next(0, 3));
                }
            }
            else // Some players are dead
            {
                var winner = _players.FirstOrDefault(p => p.HealthPoints > 0);
                
                if (losers.Count == 2) // Both players are dead
                {
                    winner = _players.ElementAt(_random.Next(0, _players.Count)); // Randomly choose winner
                }

                Winner = winner;
                End();
            }
        }

        public bool IsReadyToStart()
        {
            return _state == GameStateEnum.Created && GetPlayersCount() == 2;
        }

        public void AddPlayer(IPlayer player)
        {
            _players.Add(player);
        }

        public void KickPlayer(IPlayer player)
        {
            _players.Remove(player);
        }

        public int GetPlayersCount()
        {
            return _players.Count;
        }
    }
}
