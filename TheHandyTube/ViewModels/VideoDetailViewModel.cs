using System;
using System.Diagnostics;
using MediaManager;
using Xamarin.Forms;

namespace TheHandyTube.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class VideoDetailViewModel : BaseViewModel
    {
        private string VideoId { get; set; }
        private string _videoUrl;
        private StackLayout VideoView;

        public string VideoURL
        {
            get => _videoUrl;
            set => SetProperty(ref _videoUrl, value);
        }


        public String ItemId
        {
            get
            {
                return VideoId;
            }
            set
            {
                VideoId = value;
                LoadItem(value);
            }
        }

        public void LoadItem(string videoID)
        {
            try
            {
                VideoURL = "https://www.youtube.com/embed/" + videoID;

                //CrossMediaManager.Current.Play(VideoURL);
                //CrossMediaManager.Current.AutoPlay = true;
                //CrossMediaManager.Current.MediaPlayer.ShowPlaybackControls = true;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private void LoadPage(string videoID)
        {
            HtmlWebViewSource personHtmlSource = new HtmlWebViewSource();
            var screenWidth = Application.Current.MainPage.Width - 10;

            // According to standard video resolutions
            var playerHeight = screenWidth / 1.5;

            string header = "<head> <style> body {background-color: rgb(241, 241, 241);}</style> </head>";
            var videoUrl = "https://www.youtube.com/embed/" + videoID;
            personHtmlSource.Html = string.Format("<html>{0}<body><iframe width='{1}' height='{2}' src='{3}' frameborder='0' allow='autoplay; encrypted-media' allowfullscreen></iframe></body></html>",
                                  header, screenWidth, playerHeight, videoUrl);

            var webview = new WebView()
            {
                BackgroundColor = Color.DimGray,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            webview.Source = personHtmlSource;

            var pageStack = new StackLayout()
            {
                BackgroundColor = Color.FromRgb(241, 241, 241),
                Spacing = 0,
                Margin = 0,
                Padding = 0,
                Children = { webview }
            };

            VideoView = pageStack;
        }
    }
}
