var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Enable Routing
app.UseRouting(); //Selects endpoint

app.UseEndpoints(endpoints => //Executes endpoint
{
    //add your endpoints
    //endpoints.Map...
}); 
app.Run();
