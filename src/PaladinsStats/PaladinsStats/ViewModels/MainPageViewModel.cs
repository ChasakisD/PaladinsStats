using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using PaladinsStats.Business.Interfaces;

namespace PaladinsStats.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IPaladinsStatsManager _paladinsStatsManager;

        #region PlayerString

        private string _playerString;

        public string PlayerString
        {
            get => _playerString;
            set => SetProperty(ref _playerString, value);
        }

        #endregion

        #region GetPlayerCommand

        public ICommand GetPlayerCommand { get; }

        private async void GetPlayerAction()
        {
            if (string.IsNullOrEmpty(PlayerString)) return;
            var player = await _paladinsStatsManager.RetrievePlayerByNameFromRestServiceAsync(PlayerString);

            var parameters = new NavigationParameters{{"player", player}};

            await NavigationService.NavigateAsync("PlayerOverviewPage", parameters);
        }

        #endregion

        public MainPageViewModel(
            INavigationService navigationService,
            IPaladinsStatsManager paladinsStatsManager)
            :base(navigationService)
        {
            _paladinsStatsManager = paladinsStatsManager;

            GetPlayerCommand = new DelegateCommand(GetPlayerAction);
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + "  Prism";
        }
    }
}
