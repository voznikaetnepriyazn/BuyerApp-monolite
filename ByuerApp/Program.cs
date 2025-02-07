using ByuerApp.Domain.Entities;
using ByuerApp.Domain.Interfaces;
using ByuerApp.Infrastructure;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);//������ ��� ��������� ���������� � �������� ����������, args - ��������� ��������� ������

// Add services to the container.
//builder.Services.AddRazorPages(); ���������� �������������, ���� �� ����� ������� ��� �����, ��� ������ ��� ������������ � �������������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();//�� �������� �� ����� AddSwaggerGen
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();

var app = builder.Build();//


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())//��������� �� ���������� � ����������� �����, ��������� ���������� app?? - �� ���������� � �� �����
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();//�� �������� �� ����� UseSwagger
    app.UseSwaggerUI(); // �� �������� �� ����� UseSwaggerUI
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();

app.Run();
