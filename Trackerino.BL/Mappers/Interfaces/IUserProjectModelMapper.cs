﻿using Trackerino.BL.Models;
using Trackerino.DAL.Entities;

namespace Trackerino.BL.Mappers
{
    public interface IUserProjectModelMapper:IModelMapper<UserProjectEntity, UserProjectListModel, UserProjectDetailModel>
    {
        UserProjectListModel MapToListModel(UserProjectDetailModel detailModel);
        UserProjectEntity MapToEntity(UserProjectDetailModel model, Guid userId);
        void MapToExistingDetailModel(UserProjectDetailModel existingDetailModel, ProjectListModel project);
        UserProjectEntity MapToEntity(UserProjectListModel model, Guid userId);
    }
}