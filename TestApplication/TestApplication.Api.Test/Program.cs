using MediatR;
using TestApplication.Api.Test.RabbitHandler;
using TestApplication.RabbitMq.Bus.BusRabbit;
using TestApplication.RabbitMq.Bus.EventQueue;
using TestApplication.RabbitMq.Bus.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program));


builder.Services.AddTransient<IRabbitEventBus, RabbitEventBus>();

builder.Services.AddTransient<IEventHandler<EmailEventQueue>, EmailEventHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var eventBus = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IRabbitEventBus>();
eventBus.Subscribe<EmailEventQueue, EmailEventHandler>();

app.UseAuthorization();

app.MapControllers();

app.Run();
