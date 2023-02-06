using StudentWebApi.MiddleWare;
using StudentWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILesson, LessonService>();

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
app.MapWhen(x => x.Request.Method == "GET", internalApp =>
{
    internalApp.Run(async context =>
    {
        Console.WriteLine("MapWhen middleware");
        await context.Response.WriteAsync("MapWhen middleware");
    });
});

app.MapControllers();

app.Run();
