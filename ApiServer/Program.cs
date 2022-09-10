using ApiServer.Database;
using ApiServer.Database.Repository;
using ApiServer.Models.Contracts.Databases;
using ApiServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<ContainerService>();
builder.Services.AddScoped<IAccountDataRepository, AccountDataRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddControllers()
    .AddNewtonsoftJson();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        builder.Configuration.Bind("JwtSettings", options);
        options.Events = AuthEventsHandler.Instance;
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
