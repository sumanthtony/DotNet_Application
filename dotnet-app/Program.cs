using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealtimeChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Force app to listen on port 80 inside container
builder.WebHost.UseUrls("http://+:80");

builder.Services.AddControllers();
builder.Services.AddSignalR();

// ✅ Correct CORS for SignalR
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed(_ => true); // Allows all origins WITH credentials (safe workaround)
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

// ✅ Use named CORS policy
app.UseCors("CorsPolicy");

app.MapControllers();
app.MapHub<ChatHub>("/chathub");

app.Run();
