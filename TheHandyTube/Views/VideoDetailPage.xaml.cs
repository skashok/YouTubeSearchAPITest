using Xamarin.Forms;
using TheHandyTube.ViewModels;

namespace TheHandyTube.Views
{
    public partial class VideoDetailPage : ContentPage
    {
        public VideoDetailPage()
        {
            InitializeComponent();

            BindingContext = new VideoDetailViewModel();
        }
    }
}
