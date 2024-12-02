var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!"); //default endpoint

//Enable Routing
app.UseRouting(); //Selects endpoint

app.UseEndpoints(endpoints => //Executes endpoint
{
    //add your endpoints
    //endpoints.map(url, request delegate (request delegate means a middleware))
    endpoints.Map("/map1", async (context) =>
    {
        await context.Response.WriteAsync("Inside Map 1");
    });

    endpoints.MapGet("/map2", async (context) =>
    {
        await context.Response.WriteAsync("Inside Map 2");
    });

    endpoints.MapPost("/map3", async (context) =>
    {
        await context.Response.WriteAsync("Inside Map 3");
    });


});

//if request is other than map1 or map2 or the default one /
app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});
app.Run();
