
using Microsoft.AspNetCore.Identity;
using ToDoList.Data.Databse;
using ToDoList.Data.Repository;
using ToDoList.Services.Mapping;
using ToDoList.Services.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ToDoListConnection");
builder.Services.AddSqlServer<ToDoListDbContext>(connectionString);


builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IToDoListServices, ToDoListServices>();
builder.Services.AddScoped<IUserServices, UserService>();
builder.Services.AddAutoMapper(typeof(ToDoListMap).Assembly);


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
