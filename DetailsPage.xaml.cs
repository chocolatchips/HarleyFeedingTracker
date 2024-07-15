using HarleyFeedingTracker.Constants;
using HarleyFeedingTracker.Data;
using HarleyFeedingTracker.ViewModels;

namespace HarleyFeedingTracker;

public partial class DetailsPage : ContentPage
{
	readonly DetailsViewModel viewModel;
	ChartDataType chartDataType;

	public DetailsPage(FeedingDatabase database)
	{
		InitializeComponent();
		viewModel = new DetailsViewModel(database);
		BindingContext = viewModel;
		Init();
	}


	private void Init()
	{
		allDetailsButton.Text = Constants.TextConstants.GetAllDetails;
		pickerLabel.Text = Constants.TextConstants.DetailsDatePicker;
		if (DeviceInfo.Platform == DevicePlatform.WinUI)
		{
			var cur = App.Current;
			if (cur != null)
			{
				detailsScroll.MaximumHeightRequest = cur.Windows[0].Height / 2;
				detailsChart.MaximumHeightRequest = cur.Windows[0].Height / 2;
                detailsChart.MaximumWidthRequest = cur.Windows[0].Width / 3;
            }
		}
	}

    private void DrawChart()
    {
        var Brands = viewModel.GetChartValues(chartDataType);
        detailsChart.Labels = Brands.Keys.ToList();
        detailsChart.Values = Brands.Values.ToList();
        detailsChart.Colors = ColorConstants.ChartColors;
    }

    void GetAllDetails(object sender, EventArgs e)
	{
		viewModel.GetAllDetails();
		DrawChart();
	}

	void GetDetailsForDate(object sender, DateChangedEventArgs e)
	{
		var date = (DatePicker)sender;

		viewModel.GetDetailsForDate(date.Date);
		DrawChart();
	}

	private async void OnReturnClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

    private void OnBrandsChartButtonClicked(object sender, EventArgs e)
    {
        chartDataType = ChartDataType.Brand;
		DrawChart();
    }

    private void OnFlavoursChartButtonClicked(object sender, EventArgs e)
    {
        chartDataType = ChartDataType.Flavour;
		DrawChart();
    }

    private void OnTreatsChartButtonClicked(object sender, EventArgs e)
    {
        chartDataType = ChartDataType.Treat;
        DrawChart();
    }
}