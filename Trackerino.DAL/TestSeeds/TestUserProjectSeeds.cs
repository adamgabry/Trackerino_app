﻿using Microsoft.EntityFrameworkCore;
using Trackerino.DAL.Entities;

namespace Trackerino.DAL.TestSeeds;
public static class TestUserProjectSeeds
{
    public static readonly UserProjectEntity EmptyUserProjectEntity = new()
    {
        Id = default,
        UserId = default,
        User = default,
        ProjectId = default,
        Project = default
    };

    public static readonly UserProjectEntity UserProjectEntity = new()
    {
        Id = Guid.Parse(input: "DE1376EF-F04F-4840-86D0-351B5ACED887"),
        UserId = TestUserSeeds.UserEntity.Id,
        User = TestUserSeeds.UserEntity,
        ProjectId = TestProjectSeeds.ProjectEntity.Id,
        Project = TestProjectSeeds.ProjectEntity
    };

    public static readonly UserProjectEntity UserProjectEntity1 = new()
    {
        Id = Guid.Parse(input: "58F19566-686F-4093-A8A6-77B20EA10863"),
        UserId = TestUserSeeds.UserEntity1.Id,
        User = TestUserSeeds.UserEntity1,
        ProjectId = TestProjectSeeds.ProjectEntity.Id,
        Project = TestProjectSeeds.ProjectEntity
    };

    public static readonly UserProjectEntity UserProjectEntity2 = new()
    {
        Id = Guid.Parse(input: "87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
        UserId = TestUserSeeds.UserEntity2.Id,
        User = TestUserSeeds.UserEntity2,
        ProjectId = TestProjectSeeds.ProjectEntity.Id,
        Project = TestProjectSeeds.ProjectEntity
    };

    //To ensure that no tests reuse these clones for non-idempotent operations
    public static readonly UserProjectEntity UserProjectEntityUpdate = UserProjectEntity1 with { Id = Guid.Parse("A2E6849D-A158-4436-980C-7FC26B60C674"), User = null, Project = null, ProjectId = TestProjectSeeds.ProjectForUserProjectEntityUpdate.Id };
    public static readonly UserProjectEntity UserProjectEntityDelete = UserProjectEntity1 with { Id = Guid.Parse("30872EFF-CED4-4F2B-89DB-0EE83A74D279"), User = null, Project = null, ProjectId = TestProjectSeeds.ProjectForUserProjectEntityDelete.Id };

    public static void Seed(this ModelBuilder modelBuilder) =>
    modelBuilder.Entity<UserProjectEntity>().HasData(
            UserProjectEntity with{User = null, Project = null},
            UserProjectEntity1 with { User = null, Project = null },
            UserProjectEntity2 with { User = null, Project = null },
            UserProjectEntityUpdate,
            UserProjectEntityDelete
        );
}