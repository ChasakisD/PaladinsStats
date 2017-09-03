using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using PaladinsAPI.Models;
using Prism.Navigation;

namespace PaladinsStats.ViewModels
{
    public class PlayerOverviewPageViewModel : ViewModelBase
    {
        #region Player

        private Player _player;
        public Player Player
        {
            get => _player;
            set => SetProperty(ref _player, value);
        }

        #endregion

        public PlayerOverviewPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("player"))
            {
                Player = (Player) parameters["player"] ?? new Player {Name = "Not Found"};
            }
        }
    }
}
