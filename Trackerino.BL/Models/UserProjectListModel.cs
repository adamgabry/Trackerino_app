﻿using Trackerino.DAL.Common;
using Trackerino.DAL.Entities;

namespace Trackerino.BL.Models
{
    public record UserProjectListModel:ModelBase
    {
        public required Guid UserId { get; set; }
        public required Guid ProjectId { get; set; }
        public UserListModel? User { get; init; }
        public ProjectListModel? Project { get; init; }
        public Guid Id { get; set; }
        public static UserProjectListModel Empty => new()
        {
            Id = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            ProjectId = Guid.NewGuid(),
        };
    }
}