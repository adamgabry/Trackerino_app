﻿namespace Trackerino.App.Messages
{
    public record ProjectEditMessage
    {
        public required Guid ProjectId { get; init; }
    }
}