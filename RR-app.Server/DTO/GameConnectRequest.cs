namespace RR_app.Server.DTO
{
    public record GameConnectRequest(Guid GameId, Guid RoomId, string UserName);
}
