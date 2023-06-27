﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CFlattSampleApp.Data;

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
            options => options.MigrationsAssembly("CFlattSampleApp.Migrations"));
    })
    .Build();

await host.RunAsync();
