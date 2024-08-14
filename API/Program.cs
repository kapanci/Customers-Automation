using Business.Abstract;
using Business.Concrete;
using DataAccsesLayer.Abstract;
using DataAccsesLayer.Concrete;
using DataAccsess.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost; Database=postgres; Username=postgres; Password=Ali50512506"));

// Register services
builder.Services.AddScoped<ICustomerDal, CustomerDal>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();



builder.Services.AddScoped<ICustomerComDal, CustomerComDal>();
builder.Services.AddScoped<ICustomerComService, CustomerComManager>();



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
