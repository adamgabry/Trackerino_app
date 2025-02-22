﻿using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Trackerino.App.Messages;
using Trackerino.App.Services;
using Trackerino.BL.Facades;
using Trackerino.BL.Models;

namespace Trackerino.App.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class UserDetailViewModel : ViewModelBase, IRecipient<UserEditMessage>, IRecipient<UserActivitiesAddMessage>, IRecipient<UserActivitiesDeleteMessage>,
        IRecipient<UserProjectsAddMessage>, IRecipient<UserProjectsDeleteMessage>
    {
        private readonly IUserFacade _userFacade;
        private readonly INavigationService _navigationService;
        private readonly IAlertService _alertService;

        public Guid Id { get; set; }
        public UserDetailModel? User { get; private set; }

        public UserDetailViewModel(
            IUserFacade userFacade,
            INavigationService navigationService,
            IMessengerService messengerService,
            IAlertService alertService)
            : base(messengerService)
        {
            _userFacade = userFacade;
            _navigationService = navigationService;
            _alertService = alertService;
        }

        protected override async Task LoadDataAsync()
        {
            await base.LoadDataAsync();

            User = await _userFacade.GetAsync(Id);
        }

        [RelayCommand]
        private async Task DeleteAsync()
        {
            if (User is not null)
            {
                try
                {
                    await _userFacade.DeleteAsync(User.Id);
                    MessengerService.Send(new UserDeleteMessage());
                    _navigationService.SendBackButtonPressed();
                }
                catch (InvalidOperationException)
                {
                    //TODO await _alertService.DisplayAsync(UserDetailViewModelTexts.DeleteError_Alert_Title, UserDetailViewModelTexts.DeleteError_Alert_Message);
                }
            }
        }

        [RelayCommand]
        private async Task GoToEditAsync()
        {
            if (Guid.Parse(Preferences.Get("ActiveUser", string.Empty)) == User.Id)
            {
                await _navigationService.GoToAsync("/edit",
                    new Dictionary<string, object?> { [nameof(User)] = User });
            }
            else
            {
                await _alertService.DisplayAsync("Failed to edit", "You can not edit other users");
            }
        }

        public async void Receive(UserEditMessage message)
        {
            if (message.UserId == User?.Id)
            {
                await LoadDataAsync();
            }
        }
        public async void Receive(UserActivitiesAddMessage message)
        {
            await LoadDataAsync();
        }

        public async void Receive(UserActivitiesDeleteMessage message)
        {
            await LoadDataAsync();
        }

        public async void Receive(UserProjectsAddMessage message)
        {
            await LoadDataAsync();
        }

        public async void Receive(UserProjectsDeleteMessage message)
        {
            await LoadDataAsync();
        }
    }

}
