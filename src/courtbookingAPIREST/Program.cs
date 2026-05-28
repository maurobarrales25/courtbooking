using courtbookingAPIREST.Common.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/health/db", async (AppDbContext db) =>
{
    try
    {
        await db.Database.OpenConnectionAsync();
        await db.Database.CloseConnectionAsync();
        return Results.Ok("Conectado a Supabase");
    }
    catch (Exception ex)
    {
        var msg = ex.Message;
        if (ex.InnerException != null) msg += " | INNER: " + ex.InnerException.Message;
        if (ex.InnerException?.InnerException != null) msg += " | CAUSE: " + ex.InnerException.InnerException.Message;
        return Results.Problem(msg);
    }
});

app.Run();
