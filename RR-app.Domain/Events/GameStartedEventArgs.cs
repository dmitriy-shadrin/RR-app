using RR_app.Domain.Abstractions;

namespace RR_app.Domain.Events
{
    public class GameStartedEventArgs : EventArgs
    {
        public List<IPlayer> Players { get; set; }
    }
}