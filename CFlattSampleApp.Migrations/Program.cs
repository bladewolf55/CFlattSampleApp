using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PacifiCorp.PSPortal.Data;

IHost host = Host.CreateDefaultBuilder(args)
    // CreateDefaultBuilder automatically reads configs
    .ConfigureAppConfiguration((context, builder) =>
    {
    })
    .ConfigureServices((builder, services) =>
    {
        IConfiguration configuration = builder.Configuration;
        services.AddSqlServer<PSPortalDbContext>(
            configuration.GetConnectionString("PSPortalDb"),
            options => options.MigrationsAssembly("PacifiCorp.PSPortal.Migrations"));
    })
    .Build();

await host.RunAsync();
