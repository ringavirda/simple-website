var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(
    options => options.AllowAnyOrigin().AllowAnyMethod()
);

app.MapGet("/api/sample", () =>
{
    var response = new ApiResponse(
        Guid.NewGuid(),
        $"Hey, this was received from [{System.Net.Dns.GetHostName()}]!"
    );
    return Results.Ok(response);
});

app.MapGet("/api/ftp", () =>
{
    return Results.NotFound();
});

app.MapGet("/api/download", () => {
    
});

app.Run();

record ApiResponse(Guid Id, string? Message);
