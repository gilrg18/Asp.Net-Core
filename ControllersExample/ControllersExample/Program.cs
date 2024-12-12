using ControllersExample.Controllers;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<HomeController>();
//1-You can call this so you dont have to call each controller one by one:
builder.Services.AddControllers();

var app = builder.Build();
//2-Enable Routing
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    //to do each method one by one is insane 
//    //endpoints.Map("method1", ...);
//    //So call MapControllers instead to detect all the controllers of your project
//    endpoints.MapControllers();
//});

//Even simpler: This calls userouting and useendpoints:
app.MapControllers();


app.Run();
