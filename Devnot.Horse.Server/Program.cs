using Devnot.Horse.Server;
using Horse.Jockey;
using Horse.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder appBuilder = Host.CreateApplicationBuilder();
appBuilder.Services.AddHostedService<HorseRiderService>();
appBuilder.Services.Configure<ServerOptions>(options => { appBuilder.Configuration.GetSection("HorseServerOptions").Bind(options); });
appBuilder.Services.Configure<JockeyOptions>(options => { appBuilder.Configuration.GetSection("HorseJockeyOptions").Bind(options); });
IHost host = appBuilder.Build();

host.Run();