using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
//ProviderFactory means we are using a custom or third party service provider factory
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllersWithViews();
//builder.Services.Add(new ServiceDescriptor
//(
//    typeof(ICitiesService),
//    typeof(CitiesService),
//    ServiceLifetime.Transient
//));
//builder.Services.AddTransient<ICitiesService, CitiesService>();

//builder.Services.AddScoped<ICitiesService, CitiesService>(); //You can use this shorthand method instead of the above one

//Add services into autofac instead of the built-in DI container.
//Configure the IOC container of autofac and pass the generic parameter as container builder
builder.Host.ConfigureContainer<ContainerBuilder>
(containerBuilder =>
{
    //containerBuilder.RegisterType<CitiesService>
    //().As<ICitiesService>().InstancePerDependency
    //();//AddTransient


    containerBuilder.RegisterType<CitiesService>
    ().As<ICitiesService>().InstancePerLifetimeScope
    ();//AddScoped    
    containerBuilder.RegisterType<CitiesService2>
    ().As<ICitiesService>().InstancePerLifetimeScope
    ();//AddScoped    

    //containerBuilder.RegisterType<CitiesService>
    //().As<ICitiesService>().SingleInstance
    //();//AddSingleton  
});
//builder.Services.AddSingleton<ICitiesService, CitiesService>();



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
