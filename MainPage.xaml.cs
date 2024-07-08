using HarleyFeedingTracker.Services;
using HarleyFeedingTracker.Constants;

namespace HarleyFeedingTracker
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        HarleyServices _harleyService;


        public MainPage()
        {
            InitializeComponent();
            _harleyService = new();
        }


        private async void OnFedClicked(object sender, EventArgs e)
        {
            bool isFed = await _harleyService.GetIsFedAsync();
            fedYetButton.Text = isFed ? Text.HarleyWasFed : Text.HarleyNotFed;
        }
    }

}
