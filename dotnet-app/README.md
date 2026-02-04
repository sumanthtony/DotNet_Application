# RealtimeChat (ASP.NET Core + SignalR)

This is a small demo ASP.NET Core (net7.0) realtime chat using SignalR.

How to run locally (with .NET SDK installed):
1. `dotnet restore`
2. `dotnet run`  (or `dotnet publish -c Release -o out` then `dotnet out/RealtimeChat.dll`)
3. Open http://localhost:5000 or http://localhost:5000/index.html (or if using Docker mapped port http://localhost:8080)

How to run with Docker:
1. `docker build -t realtimechat .`
2. `docker run -p 8080:80 realtimechat`

Project layout:
- Program.cs
- Hubs/ChatHub.cs
- Controllers/HealthController.cs
- wwwroot/index.html (simple JS client using SignalR)
- Dockerfile, docker-compose.yml

Notes:
- The client uses the SignalR browser script from jsdelivr CDN.
- CORS is configured permissively for demo purposes; tighten it for production.
