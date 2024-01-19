var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(
    options => options.AllowAnyOrigin().AllowAnyMethod()
);

app.MapGet("/api", () =>
{
    var response = new ApiResponse(
        Guid.NewGuid(),
        $"Hey, this was received from [{System.Net.Dns.GetHostName()}]!"
    );
    return Results.Ok(response);
});

app.MapGet("/ftp", () =>
{
    return Results.NotFound();
});

app.MapGet("/ftp/download", () => {
    
});

app.Run();

record ApiResponse(Guid Id, string? Message);
