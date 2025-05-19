using Microsoft.EntityFrameworkCore;
using StudentAPI.Entity;
using StudentAPI.Data;
using StudentAPI.Data.EntityConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using StudentAPI.Data.Seeder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
//
//Database bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"));
});

var app = builder.Build();
//

//CORS ayarları
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
//Code First için gerekli kodlar
using var scope = app.Services.CreateScope();
using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();
//await context.Database.MigrateAsync();
DbSeeder.Seed(context);
//
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
