using StudentWebApi.MiddleWare;
using StudentWebApi.Models;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Services;
using AutoMapper;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DbStudent");
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentDbContext>(options=>
options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILesson, LessonService>();
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// A custom middleware is designed.
app.UseCustomMiddleware();
// An exception middleware is designed.
app.UseCustomExceptionMiddleware();
// simple middlewares
app.Use(async (context, next) =>
{ Console.WriteLine("actiona girildi.");
    await next.Invoke();
    });
//routed to /middleware address
app.Map("/middleware", internalApp =>
internalApp.Run(async context =>
{
    await context.Response.WriteAsync("middleware response.");
}));
// action at get requests
app.MapWhen(x => x.Request.Method == "PATCH", internalApp =>
{
    internalApp.Run(async context =>
    {
        Console.WriteLine("MapWhen middleware");
        await context.Response.WriteAsync("MapWhen middleware");
    });
});


app.MapControllers();

app.Run();
