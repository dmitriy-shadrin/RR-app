namespace RR_app.Domain.Abstractions
{
    public interface IRoom
    {
        Guid Id { get; init; }
        
        void Join(IUser user);
        void Leave(IUser user);
        int GetUsersCount();
        void Destroy();
    }
}
