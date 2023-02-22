using avtosalon.Repositories;
using avtosalon.Services;
using avtosalon.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using Web.data.AdDbConection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddDbContext<AppDbcontext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); ;
builder.Services.AddConfigurationIdentity();
builder.Services.AddConfigurationJwt(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
