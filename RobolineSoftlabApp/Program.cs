using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RobolineSoftlabApp.Domain.Repositories;
using RobolineSoftlabApp.Infrastructure.Data;
using RobolineSoftlabApp.Infrastructure.Repositories;
using RobolineSoftlabApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RobolineSoftlabAppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'RobolineSoftlabAppContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductService, ProductService>();
builder.Services.AddScoped<ProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();

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
