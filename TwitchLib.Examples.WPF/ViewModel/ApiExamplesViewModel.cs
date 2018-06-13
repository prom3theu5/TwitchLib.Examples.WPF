using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TwitchLib.Api.Interfaces;
using TwitchLib.Api.Models.Undocumented.Chatters;

namespace TwitchLib.Examples.WPF.ViewModel
{
    public class ApiExamplesViewModel : ViewModelBase
    {
        private readonly ITwitchAPI _api;
        public ObservableCollection<ChatterFormatted> LoadedChatters { get; private set; }
        public RelayCommand RefreshChattersCommand { get; private set; }
        public string ClientId { get; set; }
        public string ChannelName { get; set; }

        public ApiExamplesViewModel(ITwitchAPI api)
        {
            _api = api;
            RefreshChattersCommand = new RelayCommand(OnClickGetChatters);
            LoadedChatters = new ObservableCollection<ChatterFormatted>();
        }

        private void OnClickGetChatters()
        {
            if (string.IsNullOrEmpty(ClientId)) return;
            if (string.IsNullOrEmpty(ChannelName)) return;

            Task.Run(async () => {
                _api.Settings.ClientId = ClientId;
                var result = await _api.Undocumented.GetChattersAsync(ChannelName);
                if (result is List<ChatterFormatted>)
                    LoadedChatters = new ObservableCollection<ChatterFormatted>(result);
            });
        }
    }
}
