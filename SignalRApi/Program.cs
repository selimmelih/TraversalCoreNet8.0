using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using SignalRApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// PostgreSQL baðlantýsýný saðlayacak yapý.
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(opt =>
    {

        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
builder.Services.AddScoped<VisitorService>();
builder.Services.AddSignalR();
//dýþarýdan herhangi bir kaynaðýn bu api yi tüketmesini saðlayacak kodlar
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host)=>true).AllowCredentials();
    }
    ));

builder.Services.AddControllers();
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

app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();
app.MapHub<VisitorHub>("/VisitorHub");
app.Run();
