namespace HarleyFeedingTracker;

public partial class FeedingPage : ContentPage
{
	public FeedingPage()
	{
		InitializeComponent();
	}

	public async void ReturnButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}