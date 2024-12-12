using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    WebRootPath = "myroot"
});

var app = builder.Build();

//myroot
app.UseStaticFiles(); //Static files are the only files available through the browser

app.UseStaticFiles(new StaticFileOptions() //mywebroot
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "mywebroot")
        )
});

app.UseRouting();

//app.MapGet("/", () => "Hello World!"); this is a shortcut for this process:
app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Hello");
    });
});

app.Run();
