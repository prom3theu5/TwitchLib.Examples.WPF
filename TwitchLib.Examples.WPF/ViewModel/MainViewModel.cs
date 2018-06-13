using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace TwitchLib.Examples.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string ApiButtonText => "API Examples";
        public string ClientButtonText => "Client Examples";
        public RelayCommand ApiButtonCommand { get; private set; }
        public RelayCommand ClientButtonCommand { get; private set; }
        public MainViewModel()
        {
            ApiButtonCommand = new RelayCommand(OnClickApiButton);
            ClientButtonCommand = new RelayCommand(OnClickClientButton);
        }

        private void OnClickApiButton()
        {
            var apiWindow = new Views.ApiExamplesView();
            apiWindow.ShowDialog();
        }

        private void OnClickClientButton()
        {

        }
    }
}