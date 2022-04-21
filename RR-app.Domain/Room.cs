using RR_app.Domain.Abstractions;

namespace RR_app.Domain;

public class Room : IRoom
{
    private List<IUser> _users = new();
    public Guid Id { get; init; } = Guid.NewGuid();

    public void Destroy()
    {
        _users.Clear();
    }

    public int GetUsersCount()
    {
        return _users.Count;
    }

    public void Join(IUser user)
    {
        _users.Append(user);
    }

    public void Leave(IUser user)
    {
        _users.Remove(user);
    }
}
