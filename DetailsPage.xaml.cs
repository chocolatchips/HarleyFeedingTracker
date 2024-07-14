using HarleyFeedingTracker.Data;
using HarleyFeedingTracker.ViewModels;

namespace HarleyFeedingTracker;

public partial class DetailsPage : ContentPage
{
	readonly DetailsViewModel viewModel;

	public DetailsPage(FeedingDatabase database)
	{
		InitializeComponent();
		viewModel = new DetailsViewModel(database);
		BindingContext = viewModel;
		Init();
	}


	private void Init()
	{
		allDetailsButton.Text = Constants.Text.GetAllDetails;
		pickerLabel.Text = Constants.Text.DetailsDatePicker;
		if (DeviceInfo.Platform == DevicePlatform.WinUI)
		{
			var cur = App.Current;
			if (cur != null)
			{
				detailsScroll.MaximumHeightRequest = cur.Windows[0].Height / 2;
			}
		}
	}

	void GetAllDetails(object sender, EventArgs e)
	{
		viewModel.GetAllDetails();
	}

	void GetDetailsForDate(object sender, DateChangedEventArgs e)
	{
		var date = (DatePicker)sender;

		viewModel.GetDetailsForDate(date.Date);
	}

	private async void OnReturnClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

}