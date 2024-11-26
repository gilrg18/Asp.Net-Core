var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.Run(async (HttpContext context) =>
{
    context.Response.StatusCode = 200;

    context.Response.Headers["MyKey"] = "My Value";

    context.Response.Headers["Server"] = "Gil Server";

    string path = context.Request.Path;
    string method = context.Request.Method;

    context.Response.Headers["Content-Type"] = "text/html";
    
    if(method == "GET")
    {
        if (context.Request.Query.ContainsKey("id"))
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p>{id}</p>");
        }
    }

    await context.Response.WriteAsync($"<h1>{path}</h1>");
    await context.Response.WriteAsync($"<h1>{method}</h1>");
    await context.Response.WriteAsync("<h1>Hello </h1>");
    await context.Response.WriteAsync("<h2>World!</h2>");
});

app.Run();
