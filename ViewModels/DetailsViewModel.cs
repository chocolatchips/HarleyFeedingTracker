using HarleyFeedingTracker.Data;
using HarleyFeedingTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.ViewModels
{
    class DetailsViewModel
    {
        private readonly FeedingDatabase _database;
        
        public ObservableCollection<FeedingDetails> Details { get; set; }

        public DetailsViewModel(FeedingDatabase database)
        {
            Details = new ObservableCollection<FeedingDetails>();
            _database = database;

            LoadDetails();
        }

        private void LoadDetails()
        {
            GetAllDetails();
        }

        public async void GetAllDetails()
        {
            var dets = await _database.GetDetailsAsync();
            Details.Clear();
            foreach (var d in dets)
            {
                Details.Add(d);
            }
        }

        public async void GetDetailsForDate(DateTime date)
        {
            var dets = await _database.GetDetailsDateAsync(date);
            Details.Clear();
            foreach (var d in dets)
            {
                Details.Add(d);
            }
        }
    }
}
