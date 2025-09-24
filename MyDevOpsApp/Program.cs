var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/hello", () => "<h1>Hello, DevOps!</h1>");

app.MapGet("/", (HttpContext context) =>
{
    var name = context.Request.Query["name"];
    return Results.Content($"<h1>Hello, {name}!</h1>", "text/html");
});

// Unused variable (dead code)
var unusedVar = 12345;

// Poor exception handling: generic catch swallowing exceptions
app.MapGet("/error", () =>
{
    try
    {
        throw new Exception("Something went wrong!");
    }
    catch
    {
        return Results.Text("An error occurred.");
    }
});

// Unvalidated redirect (open redirect)
app.MapGet("/redirect", (HttpContext context) =>
{
    var target = context.Request.Query["target"];
    return Results.Redirect(target);
});


app.Run();
