using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using CleanArchitecture.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositories.Interfaces;
using CleanArchitecture.Infraestructure.Repositories;
using CleanArchitecture.Domain.Services;
using CleanArchitecture.DomainServices.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddDbContext<CleanArchitectureContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
