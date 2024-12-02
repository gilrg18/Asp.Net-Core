var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!"); //default endpoint


//Enable Routing
app.UseRouting(); //Selects endpoint


#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints => //Executes endpoint
{
    endpoints.Map("files/{filename}.{extension}", async (context) =>
    {
        //string? because we are ready to accept null values
        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In Files {filename} / {extension}");
    });

    //route names are case insensitive - doesnt matter if its upper or lower case
    endpoints.Map("employee/profile/{employeename}", async (context) =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
        await context.Response.WriteAsync($"Employee profile: {employeeName}");
    });

});
#pragma warning restore ASP0014 // Suggest using top level route registrations

//if request is other than map1 or map2 or the default one /
app.Run(async context =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});
app.Run();
