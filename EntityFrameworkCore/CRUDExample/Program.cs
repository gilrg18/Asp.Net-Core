using ServiceContracts;
using Services;
using Microsoft.EntityFrameworkCore;
using Entities; //Import Entities to access PersonsDbContext

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//add services into IoC container
//builder.Services.AddSingleton<ICountriesService, CountriesService>();
//builder.Services.AddSingleton<IPersonsService, PersonsService>();
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IPersonsService, PersonsService>();

//ADD THE DATABASE CONTEXT
builder.Services.AddDbContext<PersonsDbContext>(options =>
{
    //This works but its not recommended because it is a bad practice to mix configuration settings with your source code.
    //options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PersonsDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    //options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//Connection string goes in appsettings.json
//Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PersonsDatabase;Integrated Security=True;
//Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;
//Application Intent=ReadWrite;Multi Subnet Failover=False
var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
