using ByuerApp.Domain.Entities;
using ByuerApp.Domain.Interfaces;
using ByuerApp.Domain.Servises;
using ByuerApp.Infrastructure;
using Microsoft.Extensions.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);//������ ��� ��������� ���������� � �������� ����������, args - ��������� ��������� ������

// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("log")
    .CreateLogger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BuyerAppContext>();
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IGoodRepository, GoodRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IGoodService, GoodService>();
builder.Services.AddScoped<ITypesService, TypesService>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ITypesRepository, TypesRepository>();
builder.Services.AddScoped<IGoodRepository, GoodRepository>();

WebApplication app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())//��������� �� ���������� � ����������� �����, ��������� ���������� app?? - �� ���������� � �� �����
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run();
