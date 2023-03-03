﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Trackerino.DAL.Factories
{
    public class DefaultFactory : IDesignTimeDbContextFactory<TrackerinoDbContext>
    {
        public TrackerinoDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<TrackerinoDbContext> builder = new();
            builder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                                   Initial Catalog = Trackerino;
                                   MultipleActiveResultSets = True;
                                   Encrypt = False;
                                   TrustServerCertificate = True;");
                return new TrackerinoDbContext(builder.Options);
        }
    }
}
