﻿using Microsoft.EntityFrameworkCore;
using Trackerino.BL.Mappers;
using Trackerino.DAL;
using Trackerino.DAL.Factories;


namespace Trackerino.App;

public static class DALInstaller
{
    public static IServiceCollection AddDALServices(this IServiceCollection services)
    {
        //string connectionString =
        //    "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog = Trackerino; MultipleActiveResultSets = True; Integrated Security = True; Encrypt=False; TrustServerCertificate = True;";

        //services.AddSingleton<IDbContextFactory<TrackerinoDbContext>>(provider => new SqlServerDbContextFactory(connectionString));
        services.AddSingleton<IDbContextFactory<TrackerinoDbContext>>(provider => new DbContextSqLiteFactory("Trackerino",true));
        services.AddSingleton<IDbMigrator, SqLiteDbMigrator>();

        services.AddSingleton<ActivityModelMapper>();
        services.AddSingleton<ProjectModelMapper>();
        services.AddSingleton<ProjectUserModelMapper>();
        services.AddSingleton<UserModelMapper>();
        services.AddSingleton<UserProjectActivityModelMapper>();
        services.AddSingleton<UserProjectModelMapper>();

        return services;
    }
}