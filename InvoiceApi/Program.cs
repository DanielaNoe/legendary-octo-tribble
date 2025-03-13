using InvoiceApi.Data;
using InvoiceApi.Helper;
using InvoiceApi.Repositories;
using InvoiceApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<InvoiceRepositoryInterface, InvoiceRepository>();
builder.Services.AddScoped<OrderRepositoryInterface, OrderRepository>();

builder.Services.AddScoped<InvoiceServiceInterface, InvoiceService>();
builder.Services.AddScoped<OrderServiceInterface, OrderService>();

builder.Services.AddSingleton<OrderMapper>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();