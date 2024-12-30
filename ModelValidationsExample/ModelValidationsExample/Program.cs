using ModelValidationsExample.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    //In order to override the Default Binder Provider we have to insert 
    //our custom Binder Provider in the index 0
    options.ModelBinderProviders.Insert(0, new PersonBinderProvider());
});
builder.Services.AddControllers().AddXmlSerializerFormatters();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
