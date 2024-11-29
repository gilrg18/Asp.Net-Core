var builder = WebApplication.CreateBuilder(args);

//Application builder object is used to enable or create middleware
var app = builder.Build();

//The extension mehtod called 'RUN' is used to execute a terminating/short-
//circuiting middleware that doesnt forward the request to the next middleware
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello");
});

//The second middleware doesnt execute after completion of the first(above) middleware
//App.Run method doesnt forward the request to the subsequent middleware
//As a result we wont see 'Hello Again'
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello Again");
});
//A middleware SHOULD be able to forward the request to the subsequent middleware, this is called middleware chain.
app.Run();
