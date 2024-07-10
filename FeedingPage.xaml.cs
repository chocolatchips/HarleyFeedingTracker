using HarleyFeedingTracker.Data;
using HarleyFeedingTracker.Models;
using HarleyFeedingTracker.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace HarleyFeedingTracker;

public partial class FeedingPage : ContentPage
{
	readonly FeedingDatabase database;
	ObservableCollection<FoodBrand> Brands { get; set; } = new();
	readonly FeedingViewModel viewModel;

	public FeedingPage(FeedingDatabase feedingDatabase)
	{
		InitializeComponent();
		database = feedingDatabase;
		viewModel = new FeedingViewModel(feedingDatabase);
		BindingContext = viewModel;
    }

	async void ReturnButtonClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

	async void SaveButtonClicked(object sender, EventArgs e)
	{
		int res = await viewModel.SaveFeeding();
		if (res != 0)
			await Shell.Current.GoToAsync("..");
		
	}

	void OnBrandPickerSelection(object sender, EventArgs e)
	{
		var picker = (Picker)sender;

		int selectedIndex = picker.SelectedIndex;

		if (selectedIndex != -1)
		{
			viewModel.SelectedBrand = picker.Items[selectedIndex];
		}
	}

	void OnFlavourPickerSelection(object sender, EventArgs e)
	{
        var picker = (Picker)sender;

        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            viewModel.SelectedFlavour = picker.Items[selectedIndex];
        }
    }

	void OnTreatPickerSelection(object sender, EventArgs e)
	{
		var picker = (Picker)sender;

		int selectedIndex = picker.SelectedIndex;

		if (selectedIndex != -1)
		{
			viewModel.SelectedTreat = picker.Items[selectedIndex];
		}
	}
}