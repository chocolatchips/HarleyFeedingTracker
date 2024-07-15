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
            feedButton.Text = TextConstants.FeedHarleyQuestion;

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
                fedYetButton.Text = TextConstants.HarleyWasFed;
            }
            else
            {
                fedYetButton.Text = TextConstants.HarleyNotFed;
                feedButton.IsVisible = true;
            }
        }

        private async void OnFeedButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(FeedingPage), true);
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            fedYetButton.Text = TextConstants.FeedHarleyQuestion;
            feedButton.IsVisible = false;
        }

        private async void OnDetailsButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(DetailsPage), true);
        }
    }

}
