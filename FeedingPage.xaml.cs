using HarleyFeedingTracker.Data;
using HarleyFeedingTracker.Models;
using HarleyFeedingTracker.Services;
using HarleyFeedingTracker.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace HarleyFeedingTracker;

public partial class FeedingPage : ContentPage
{
	readonly FeedingViewModel viewModel;
	readonly IHarleyServices _harleyServices;

	public FeedingPage(FeedingDatabase feedingDatabase, IHarleyServices services)
	{
		InitializeComponent();
		viewModel = new FeedingViewModel(feedingDatabase);
		_harleyServices = services;
		BindingContext = viewModel;
    }

	async void ReturnButtonClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("..");
	}

	async void SaveButtonClicked(object sender, EventArgs e)
	{
		int res = await viewModel.SaveFeeding();
		bool saved = await _harleyServices.ChangeIsFedAsync();
		if (res != 0 && saved)
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