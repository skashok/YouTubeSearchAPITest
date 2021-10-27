using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using TheHandyTube.Models;
using TheHandyTube.Views;
using TheHandyTube.ViewModels;
using TheHandyTube.Services;

namespace TheHandyTube.Views
{
    public partial class SearchVideosPage : ContentPage
    {
        SearchVideosViewModel _viewModel;

        YouTubeSearchServie youTubeSearchServie;

        public SearchVideosPage()
        {
            InitializeComponent();

            youTubeSearchServie = new YouTubeSearchServie();

            BindingContext = _viewModel = new SearchVideosViewModel(youTubeSearchServie);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
