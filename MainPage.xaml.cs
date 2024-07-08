using HarleyFeedingTracker.Services;

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
            //fedYetButton.Text = "No. Please feed me.";

            fedYetButton.Text = await _harleyService.GetIsFedAsync();
        }
    }

}
