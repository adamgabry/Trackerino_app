﻿using Microsoft.EntityFrameworkCore;
using Trackerino.DAL.Common;
using Trackerino.DAL.Entities;

namespace Trackerino.DAL.TestSeeds;

public static class TestActivitySeeds
{
    public static readonly ActivityEntity EmptyActivityEntity = new()
    {
        Id = default,
        Tag = default,
        Description = default!,
        StartDateTime = default,
        EndDateTime = default,
        UserId = default,
        ProjectId = default
    };

    public static readonly ActivityEntity ActivityEntity = new()
    {
        Id = Guid.Parse(input: "4FA608F9-77D2-498B-A6C1-387FDA3DFB3D"),
        Tag = ActivityTag.Work,
        Description = "Hour long meeting",
        StartDateTime = new DateTime(2023, 1, 24, 14, 0, 0),
        EndDateTime = new DateTime(2023, 1, 24, 15, 0, 0),
        UserId = TestUserSeeds.UserEntity.Id,
        ProjectId = TestProjectSeeds.ProjectEntity.Id
    };

    //To ensure that no tests reuse these clones for non-idempotent operations
    public static readonly ActivityEntity ActivityEntityUpdate = ActivityEntity with { Id = Guid.Parse("143332B9-080E-4953-AEA5-BEF64679B052"), ProjectId = TestProjectSeeds.ProjectEntity.Id, UserId = TestUserSeeds.UserEntity.Id };
    public static readonly ActivityEntity ActivityEntityDelete = ActivityEntity with { Id = Guid.Parse("274D0CC9-A948-4818-AADB-A8B4C0506619"), ProjectId = TestProjectSeeds.ProjectEntity.Id, UserId = TestUserSeeds.UserEntity.Id };

    public static ActivityEntity ActivityEntity1 = new()
    {
        Id = Guid.Parse(input: "FCCCCD03-FA27-46D8-950D-7A5D9FD1B103"),
        Description = "Seeded Activity 1 description",
        Tag = ActivityTag.Work,
        StartDateTime = new DateTime(2023, 12, 24, 20, 0, 0),
        EndDateTime = new DateTime(2023, 12, 24, 22, 0, 0),
        UserId = TestUserSeeds.UserEntity1.Id,
        ProjectId = TestProjectSeeds.ProjectEntity.Id
    };

    public static ActivityEntity ActivityEntity2 = new()
    {
        Id = Guid.Parse(input: "F7EDB698-5130-4FCB-8F49-C1AC22DACFE8"),
        Description = "Seeded Activity 2 description",
        Tag = ActivityTag.None,
        StartDateTime = new DateTime(2023, 1, 1, 8, 0, 0),
        EndDateTime = new DateTime(2023, 1, 1, 9, 0, 0),
        UserId = TestUserSeeds.UserEntity2.Id,
        ProjectId = TestProjectSeeds.ProjectEntity.Id,
    };

    static TestActivitySeeds()
    {
        ActivityEntity.Project = TestProjectSeeds.ProjectEntity;
        ActivityEntity.User = TestUserSeeds.UserEntity;

        ActivityEntity1.Project = TestProjectSeeds.ProjectEntity;
        ActivityEntity1.User = TestUserSeeds.UserEntity1;

        ActivityEntity2.Project = TestProjectSeeds.ProjectEntity;
        ActivityEntity2.User = TestUserSeeds.UserEntity2;
    }
    public static void Seed(this ModelBuilder modelBuilder)=>
        modelBuilder.Entity<ActivityEntity>().HasData(
            ActivityEntity1 with { User = null, Project = null},
            ActivityEntity2 with { User = null, Project = null },
            ActivityEntity with { User = null, Project = null },
            ActivityEntityUpdate,
            ActivityEntityDelete
            );
}

