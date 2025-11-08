using BusnissLogic;
using Core.Application.BusnissLogic;
using Core.Application.DB;
using DBHandler.Dapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependancy Injection

builder.Services.AddSingleton<IGeneric_CRUD, Generic_CRUD>();
builder.Services.AddSingleton<ITravelAgency_DbContext,TravelAgency_DbContext>();
builder.Services.AddSingleton<IClient_Handler,Client_Handler>();
builder.Services.AddSingleton<IUsers_Handler,User_Handler>();
builder.Services.AddSingleton<IOrder_Handler,Order_Handler>();
builder.Services.AddSingleton<ITravelPlans_Handler,TravelPlans_Handler>();





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
