﻿using Microsoft.EntityFrameworkCore;
using Trackerino.DAL.Entities;

namespace Trackerino.DAL.TestSeeds;

public static class TestProjectSeeds
{
    public static readonly ProjectEntity EmptyProjectEntity = new()
    {
        Id = default,
        Name = default!,
    };

    public static readonly ProjectEntity ProjectEntity = new()
    {
        Id = Guid.Parse(input: "0D7D53AE-D631-4DAA-8C71-C3370E69A16B"),
        Name = "Project seed",

    };

    //To ensure that no tests reuse these clones for non-idempotent operations
    public static readonly ProjectEntity ProjectEntityWithNoActivities = ProjectEntity with { Id = Guid.Parse("229EC7A1-58BF-4269-8A82-EC741A5ABFAC")};
    public static readonly ProjectEntity ProjectEntityWithNoUsers = ProjectEntity with { Id = Guid.Parse("98B7F7B6-0F51-43B3-B8C0-B5FCFFF6DC2E") };
    public static readonly ProjectEntity ProjectEntityUpdate = ProjectEntity with { Id = Guid.Parse("0953F3CE-7B1A-48C1-9796-D2BAC7F67868") };
    public static readonly ProjectEntity ProjectEntityDelete = ProjectEntity with { Id = Guid.Parse("5DCA4CEA-B8A8-4C86-A0B3-FFB78FBA1A09") };

    public static readonly ProjectEntity ProjectForUserProjectEntityUpdate = ProjectEntity with { Id = Guid.Parse("4FD824C0-A7D1-48BA-8E7C-4F136CF8BF31") };
    public static readonly ProjectEntity ProjectForUserProjectEntityDelete = ProjectEntity with { Id = Guid.Parse("F78ED923-E094-4016-9045-3F5BB7F2EB88") };


    static TestProjectSeeds()
    {
        ProjectEntity.Activities.Add(TestActivitySeeds.ActivityEntity);
        ProjectEntity.Activities.Add(TestActivitySeeds.ActivityEntity1);
        ProjectEntity.Activities.Add(TestActivitySeeds.ActivityEntity2);

        ProjectEntity.Users.Add(TestUserProjectSeeds.UserProjectEntity);
        ProjectEntity.Users.Add(TestUserProjectSeeds.UserProjectEntity1);
        ProjectEntity.Users.Add(TestUserProjectSeeds.UserProjectEntity2);

        ProjectForUserProjectEntityDelete.Users.Add(TestUserProjectSeeds.UserProjectEntityDelete);
    }

    public static void Seed(this ModelBuilder modelBuilder)=>
    modelBuilder.Entity<ProjectEntity>().HasData(
            ProjectEntity with{Users = Array.Empty<UserProjectEntity>(), Activities = Array.Empty<ActivityEntity>()},
            ProjectEntityWithNoActivities with { Users = Array.Empty<UserProjectEntity>(), Activities = Array.Empty<ActivityEntity>() },
            ProjectEntityWithNoUsers with { Users = Array.Empty<UserProjectEntity>(), Activities = Array.Empty<ActivityEntity>() },
            ProjectEntityUpdate with { Users = Array.Empty<UserProjectEntity>(), Activities = Array.Empty<ActivityEntity>() },
            ProjectEntityDelete with { Users = Array.Empty<UserProjectEntity>(), Activities = Array.Empty<ActivityEntity>() },
            ProjectForUserProjectEntityUpdate with { Users = Array.Empty<UserProjectEntity>(), Activities = Array.Empty<ActivityEntity>() },
            ProjectForUserProjectEntityDelete with { Users = Array.Empty<UserProjectEntity>(), Activities = Array.Empty<ActivityEntity>() }
        );
    
}

