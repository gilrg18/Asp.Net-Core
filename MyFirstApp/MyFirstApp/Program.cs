using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.Run(async (HttpContext context) =>
{
    string firstNumberQuery = context.Request.Query["firstNumber"];
    string secondNumberQuery = context.Request.Query["secondNumber"];
    string operation = context.Request.Query["operation"];

    var errorMessages = new List<string>();
    if (!int.TryParse(firstNumberQuery, out int firstNumber))
    {
        errorMessages.Add("Invalid input for 'firstNumber'.");
    }

    if (!int.TryParse(secondNumberQuery, out int secondNumber))
    {
        errorMessages.Add("Invalid input for 'secondNumber'.");
    }

    string[] validOperations = { "add", "subtract", "multiply", "divide", "module" };
    if (string.IsNullOrEmpty(operation) || !validOperations.Contains(operation))
    {
        errorMessages.Add("Invalid input for 'operation'.");
    }


    if (errorMessages.Count > 0)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync(string.Join("\n", errorMessages));
        return;
    }

    switch (operation)
    {
        case "add":
            await context.Response.WriteAsync($"Result: {firstNumber + secondNumber}");
            break;

        case "subtract":
            await context.Response.WriteAsync($"Result: {firstNumber - secondNumber}");
            break;

        case "multiply":
            await context.Response.WriteAsync($"Result: {firstNumber * secondNumber}");
            break;

        case "divide":
            await context.Response.WriteAsync($"Result: {firstNumber / secondNumber}");
            break;

        case "module":
            await context.Response.WriteAsync($"Result: {firstNumber % secondNumber}");
            break;

        default:
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'operation'");
            break;
    }

});

app.Run();
