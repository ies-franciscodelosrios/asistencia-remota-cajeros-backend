using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using Proyecto_BackEnd.Context;
using Proyecto_BackEnd.Controllers;
using Proyecto_BackEnd.HubConfig;
using Proyecto_BackEnd.Model;
using Proyecto_BackEnd.Repository;
using Proyecto_BackEnd.Service;
using System.Configuration;
using System.Net;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200", "http://localhost:58542", "https://localhost:5100", "https://192.168.10.236:5100", "https://localhost:5000", "https://192.168.10.236:5000");
                          policy.WithHeaders("*");
                          policy.WithMethods("*");
                          policy.AllowCredentials();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();


builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<CajeroRepository>();
builder.Services.AddScoped<CajeroService>();
builder.Services.AddScoped<CajeroController>();
builder.Services.AddScoped<CallRepository>();
builder.Services.AddScoped<CallService>();
builder.Services.AddScoped<CallController>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapHub<CallHub>("/call");
/*app.Use(async (context, next) =>
{
    // Log incoming request
    Console.WriteLine($"Incoming request: {context.Request.Host.ToString}");

    // Call the next middleware in the pipeline
    await next.Invoke();

    // Log the outgoing response
    Console.WriteLine($"Outgoing response: {context.Response.StatusCode}");
});*/






app.UseCors(MyAllowSpecificOrigins);
app.UseRouting();
app.UseAuthorization();
app.UseWebSockets();

app.MapControllers();

app.Run();