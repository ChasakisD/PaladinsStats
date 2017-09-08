using Prism.Mvvm;

namespace PaladinsStats.Model.Models
{
    public class UserSettings : BindableBase
    {
        private string _currentPatchInfo;
        public string CurrentPatchInfo
        {
            get => _currentPatchInfo;
            set => SetProperty(ref _currentPatchInfo, value);
        }

        private string _authenticationToken;
        public string AuthenticationToken
        {
            get => _authenticationToken;
            set => SetProperty(ref _authenticationToken, value);
        }
    }
}
