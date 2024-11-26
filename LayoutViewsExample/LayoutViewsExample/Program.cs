//GITHUB REPO: https://github.com/Harsha-Global/AspNetCore-Harsha
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.Run();
