using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
//Use your custom Middleware
builder.Services.AddTransient<MyCustomMiddleware>();

//Application builder object is used to enable or create middleware
var app = builder.Build();

//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 2 ");
    await next(context); //to call the subsequent middleware 
});

//Middleware 2 - CustomMiddleware. lets say your middleware has a lot of logic so you create
//it in another file to avoid big files and confusion
app.UseMiddleware<MyCustomMiddleware>();

//Middleware 3 (App.Run is a terminating/short-circuit middleware)
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Middleware 3 ");
});
app.Run();
