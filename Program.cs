/*
    Date 2 Mar 202
*/

using CSTV_v1.Data;
using CSTV_v1.Services.Player;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// implementações
builder.Services.AddScoped<IPlayerInterface, PlayerService>();
builder.Services.AddScoped<IProfileInterface, ProfileService>();

builder.Services.AddDbContext<AppDbContext>( options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
