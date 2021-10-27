using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

using Xamarin.Forms;

using TheHandyTube.Models;
using TheHandyTube.Services;
using TheHandyTube.Views;
using System.Threading.Tasks;

namespace TheHandyTube.ViewModels
{
    public class SearchVideosViewModel : BaseViewModel
    {
        private VideoItems _selectedItem;
        private YouTubeSearchServie _youTubeSearchSerice;
        public ObservableCollection<VideoItems> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<VideoItems> ItemTapped { get; }

        private Command _searchYoutubeCommand;

        private String _filterText;


        public SearchVideosViewModel(YouTubeSearchServie youTubeSearchSerice)
        {
            Title = "Search";
            Items = new ObservableCollection<VideoItems>();
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());
            this._youTubeSearchSerice = youTubeSearchSerice;
            ItemTapped = new Command<VideoItems>(OnItemSelectedAsync);
        }


        public String FilterText
        {
            get
            {
                return _filterText;
            }

            set
            {
                if (_filterText == value) return;
                _filterText = value;

            }
        }

       
        void ExecuteLoadItemsCommand()
        {
            ReloadVideos();
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public VideoItems SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelectedAsync(value);
            }
        }

        async void OnItemSelectedAsync(VideoItems item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(VideoDetailPage)}?{nameof(VideoDetailViewModel.ItemId)}={item.ID.VideoId}");
        }

        private async void ReloadVideos()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await this._youTubeSearchSerice.GetSearchResultAsync(FilterText, true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Command SearchLiveVideosCommand
        {
            get
            {
                return _searchYoutubeCommand ??
                    (_searchYoutubeCommand = new Command(
                        () => ReloadVideos(),
                        () => !IsBusy
                    ));
            }
        }

        public void OnAcceptCandiate(object obj)
        {

        }
    }
}
