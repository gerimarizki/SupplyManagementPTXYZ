using Microsoft.EntityFrameworkCore;
using SupplyManagement.Contracts;
using SupplyManagement.Data;
using SupplyManagement.Models;
using SupplyManagement.Repositories;
using SupplyManagement.Services;
using SupplyManagement.Handlers;
using SupplyManagement.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// membuat db context dan memanggil connection string di appsetting.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BookingDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
// Add Repository to the container
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IManagerLogistic, ManagerLogisticsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();

// Add Service to the container
builder.Services.AddScoped<CompanyServices>();
builder.Services.AddScoped<ManagerLogisticServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<VendorServices>();
builder.Services.AddScoped<AuthenticationServices>();

// Add Token Handler
builder.Services.AddScoped<ITokenHandler, TokenHandler>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
