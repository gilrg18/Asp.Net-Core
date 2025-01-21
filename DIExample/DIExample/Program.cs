using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//builder.Services.Add(new ServiceDescriptor
//(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Transient
//));
//builder.Services.AddTransient<ICitiesService, CitiesService>();
builder.Services.AddScoped<ICitiesService, CitiesService>(); //You can use this shorthand method instead of the above one
//builder.Services.AddSingleton<ICitiesService, CitiesService>();



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
