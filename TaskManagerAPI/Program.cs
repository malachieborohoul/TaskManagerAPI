using Microsoft.EntityFrameworkCore;
using StatusManagerAPI.Repositories;
using TaskManagerAPI.Data;
using TaskManagerAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskManagerDbContext>(optionsAction: options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("TaskManagerConnectionString")));

builder.Services.AddScoped<ITaskRepository, SQLTaskRepository>();

builder.Services.AddScoped<IStatusRepository, SQLStatusRepository>();


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