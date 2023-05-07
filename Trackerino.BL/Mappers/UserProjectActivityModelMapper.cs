﻿using Trackerino.BL.Mappers.Interfaces;
using Trackerino.BL.Models;
using Trackerino.DAL.Entities;

namespace Trackerino.BL.Mappers
{
    public class UserProjectActivityModelMapper : ModelMapperBase<ActivityEntity, UserProjectActivityListModel, UserProjectActivityDetailModel>, IUserProjectActivityModelMapper
    {
        private readonly IUserModelMapper _userModelMapper;
        private readonly IProjectModelMapper _projectModelMapper;

        public UserProjectActivityModelMapper(IUserModelMapper userModelMapper, IProjectModelMapper projectModelMapper)
        {
            _userModelMapper = userModelMapper;
            _projectModelMapper = projectModelMapper;
        }

        public override UserProjectActivityListModel MapToListModel(ActivityEntity? entity)
            => entity?.Project is null
                ? UserProjectActivityListModel.Empty
                : new UserProjectActivityListModel
                {
                    Id = entity.Id,
                    ActivityId = entity.Id,
                    StartDateTime = entity.StartDateTime,
                    EndDateTime = entity.EndDateTime,
                    Tag = entity.Tag
                };

        public override UserProjectActivityDetailModel MapToDetailModel(ActivityEntity? entity)
            => entity?.Project is null
                ? UserProjectActivityDetailModel.Empty
                : new UserProjectActivityDetailModel
                {
                    Id = entity.Id,
                    ActivityId = entity.Id,
                    StartDateTime = entity.StartDateTime,
                    EndDateTime = entity.EndDateTime,
                    Description = entity.Description,
                    Tag = entity.Tag

                };
        public UserProjectActivityListModel MapToListModel(UserProjectActivityDetailModel detailModel)
            => new()
            {
                Id = detailModel.Id,
                ActivityId = detailModel.Id,
                StartDateTime = detailModel.StartDateTime,
                EndDateTime = detailModel.EndDateTime,
                Tag = detailModel.Tag


            };

        public void MapToExistingDetailModel(UserProjectActivityDetailModel existingDetailModel,
            ActivityListModel activity)
        {
            existingDetailModel.Id = activity.Id;

        }

        public override ActivityEntity MapToEntity(UserProjectActivityDetailModel model)
            => throw new NotImplementedException("This method is unsupported. Use the other overload.");


        public ActivityEntity MapToEntity(UserProjectActivityDetailModel model, Guid userId, Guid projectId)
            => new()
            {
                Id = model.Id,
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                Tag = model.Tag,
                Description = model.Description

            };

        public ActivityEntity MapToEntity(UserProjectActivityListModel model, Guid userId, Guid projectId)
            => new()
            {
                Id = model.Id,
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                Tag = model.Tag,

            };
    }
}