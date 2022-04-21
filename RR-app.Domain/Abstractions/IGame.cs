using RR_app.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_app.Domain.Abstractions
{
    public interface IGame
    {
        Guid Id { get; init; }
        event GameStartedEventHandler GameStarted;
        event GameCompletedEventHandler GameCompleted;
        GameStateEnum State { get; }
        Task StartAsync();
        void PerformIteration();
        void End();
        void AddPlayer(IPlayer player);
        void KickPlayer(IPlayer player);
        bool IsReadyToStart();
        int GetPlayersCount();
    }
}
