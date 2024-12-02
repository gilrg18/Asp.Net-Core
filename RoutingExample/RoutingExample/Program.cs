var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!"); //default endpoint

app.Use(async (context, next) =>
{
    //By the time we use this GetEndpoint UseRouting hasnt executed so the
    //endpoint waqs not recognized and this returns null
    //Add '?' nullable type because endPoint might be null and here it WILL be null
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"Endpoint null: {endPoint.DisplayName}\n");

    }
    await next(context);
});
//Enable Routing
app.UseRouting(); //Selects endpoint

app.Use(async (context, next) =>
{
    Microsoft.AspNetCore.Http.Endpoint? endPoint = context.GetEndpoint();
    if (endPoint != null)
    {
        await context.Response.WriteAsync($"Endpoint: {endPoint.DisplayName}\n");

    }
    await next(context);
});

#pragma warning disable ASP0014 // Suggest using top level route registrations
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
#pragma warning restore ASP0014 // Suggest using top level route registrations

//if request is other than map1 or map2 or the default one /
app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});
app.Run();
