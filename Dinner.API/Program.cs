using BuberDinner.Application.Authentication;
using Microsoft.AspNetCore.Authentication;
using BuberDinner.Application;
using BuberSinner.Infrastructure;
using DDD_Tutorial.Common.Mapping;
using DDD_Tutorial;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddPresentation()
        .AddInfrastructure(builder.Configuration);    
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

