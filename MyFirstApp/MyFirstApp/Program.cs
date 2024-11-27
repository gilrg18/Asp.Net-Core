var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.Run(async (HttpContext context) =>
{
    context.Response.StatusCode = 200;

    context.Response.Headers["MyKey"] = "My Value";

    context.Response.Headers["Server"] = "Gil Server";

    context.Response.Headers["Content-Type"] = "text/html";
    await context.Response.WriteAsync("<h1>Hello </h1>");
    await context.Response.WriteAsync("<h2>World!</h2>");
});

app.Run();
