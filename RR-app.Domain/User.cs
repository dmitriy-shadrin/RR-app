using RR_app.Domain.Abstractions;

namespace RR_app.Domain;

public class User : IUser
{
    public string Id { get; set; }
    public string Name { get; set; }
}
