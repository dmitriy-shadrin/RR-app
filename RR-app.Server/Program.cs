using Microsoft.EntityFrameworkCore;
using RR_app.BL.Managers;
using RR_app.BL.Managers.Abstractions;
using RR_app.BL.Services;
using RR_app.BL.Services.Abstractions;
using RR_app.DAL;
using RR_app.Repository;
using RR_app.Repository.Abstractions;
using RR_app.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddSingleton<IRoomsManager, RoomsManager>();
builder.Services.AddSingleton<IGamesManager, GamesManager>();
builder.Services.AddTransient<IGameResultService, GameResultService>();

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddDbContext<DBContext>(options => options.UseInMemoryDatabase(databaseName: "RR-games"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapHub<RoomHub>("/room");
    endpoints.MapHub<GameHub>("/game");
});

app.Run();
