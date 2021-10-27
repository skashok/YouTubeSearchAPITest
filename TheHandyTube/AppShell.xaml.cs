using TheHandyTube.Views;
using Xamarin.Forms;

namespace TheHandyTube
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(VideoDetailPage), typeof(VideoDetailPage));

        }

    }
}
