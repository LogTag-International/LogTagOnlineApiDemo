using System.Diagnostics;
using System.Reflection;
using Api.Extensions;
using Module;

// We will pass this to the endpoint module and service module auto discovery which lives in an external assembly
Assembly mainAssembly = Assembly.GetAssembly(typeof(Program)) ?? throw new UnreachableException();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.RegisterServiceModules(mainAssembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandleMiddleware();

app.MapEndpoints(mainAssembly);

app.Run();
