using HarleyFeedingTracker.Services;
using HarleyFeedingTracker.Constants;

namespace HarleyFeedingTracker
{
    public partial class MainPage : ContentPage
    {
        IHarleyServices _harleyService;


        public MainPage(IHarleyServices service)
        {
            InitializeComponent();
            _harleyService = service;
            feedButton.Text = Text.FeedHarleyQuestion;

            if (DateTime.Now.Hour >= 12)
                harleyImage.Source = "harleynight.jpeg";
            else
                harleyImage.Source = "harleyandnala.jpeg";
        }


        private async void OnFedClicked(object sender, EventArgs e)
        {
            bool isFed = await _harleyService.GetIsFedAsync();
            if (isFed)
            {
                fedYetButton.Text = Text.HarleyWasFed;
            }
            else
            {
                fedYetButton.Text = Text.HarleyNotFed;
                feedButton.IsVisible = true;
            }
        }

        private async void OnFeedButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(FeedingPage), true);
        }
    }

}
