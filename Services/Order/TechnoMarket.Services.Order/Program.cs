using Microsoft.Extensions.Options;
using TechnoMarket.Services.Order.Data;
using TechnoMarket.Services.Order.Data.Interfaces;
using TechnoMarket.Services.Order.Middlewares;
using TechnoMarket.Services.Order.Services;
using TechnoMarket.Services.Order.Services.Interfaces;
using TechnoMarket.Services.Order.Settings;
using TechnoMarket.Services.Order.Settings.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Options Pattern
builder.Services.Configure<OrderDatabaseSettings>(builder.Configuration.GetSection(nameof(OrderDatabaseSettings)));
builder.Services.AddSingleton<IOrderDatabaseSettings>(sp => sp.GetRequiredService<IOptions<OrderDatabaseSettings>>().Value);

//Database
builder.Services.AddScoped<IOrderContext, OrderContext>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Service
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Custom middleware
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
