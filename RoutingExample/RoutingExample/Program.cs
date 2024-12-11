using RoutingExample.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
//We have to register our custom constraint in our builder
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint)); //(name of the constraint, custom constraint class)
});
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
    endpoints.Map("employee/profile/{employeename:length(3,7):alpha=Mike}", async (context) =>
    {
        string? employeeName = Convert.ToString(context.Request.RouteValues["employeename"]);
        await context.Response.WriteAsync($"Employee profile: {employeeName}");
    });

    //Eg: products/details/1
    //default values for optional parameters (id?) is null
    endpoints.Map("products/details/{id:int:range(1,1000)?}", async (context) =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"Given id: {id}");
        }
        else
        {
            await context.Response.WriteAsync($"Id is not supplied");
        }
    });

    //Eg: daily-digest-report/{reportdate}
    endpoints.Map("daily-digest-report/{reportdate:datetime}", async context =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"Daily-Digest-Report - {reportDate.ToShortDateString()}");
    });

    //Eg: cities/cityid
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!); // '!' means the value cannot be null
        await context.Response.WriteAsync($"City info - {cityId}");
    });

    //Eg: sales-report/2030/apr
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);// '?' means we are accepting null values
        await context.Response.WriteAsync($"Sales Report for {month}/{year}");
    });
});
#pragma warning restore ASP0014 // Suggest using top level route registrations

//if request is other than map1 or map2 or the default one /
app.Run(async context =>
{
    await context.Response.WriteAsync($"No route matched at {context.Request.Path}");
});
app.Run();
