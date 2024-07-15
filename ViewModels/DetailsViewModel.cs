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

    public enum ChartDataType
    {
        Brand = 0,
        Flavour = 1,
        Treat = 2
    }

    class DetailsViewModel
    {
        private readonly FeedingDatabase _database;
        
        public ObservableCollection<FeedingDetails> Details { get; set; }
        public Dictionary<string, float> ChartValues { get; set; }

        

        public DetailsViewModel(FeedingDatabase database)
        {
            Details = [];
            ChartValues = new Dictionary<string, float>();
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

        public Dictionary<string, float> GetChartValues(ChartDataType option)
        {
            switch (option)
            {
                case ChartDataType.Brand:
                    GetBrandsForChart();
                    break;
                case ChartDataType.Flavour:
                    GetFlavoursForChart();
                    break;
                case ChartDataType.Treat:
                    GetTreatsForChart();
                    break;
                default:
                    ChartValues.Clear();
                    break;
            }
            return ChartValues;
        }


        private void GetBrandsForChart()
        {
            ChartValues.Clear();

            foreach (var detail in Details)
            {
                bool res = ChartValues.TryAdd(detail.Brand, 1);
                if (!res)
                    ChartValues[detail.Brand]++;
            }
        }

        private void GetFlavoursForChart()
        {
            ChartValues.Clear();

            foreach (var detail in Details)
            {
                bool res = ChartValues.TryAdd(detail.Flavour, 1);
                if (!res)
                    ChartValues[detail.Flavour]++;
            }
        }

        private void GetTreatsForChart()
        {
            ChartValues.Clear();

            foreach (var detail in Details)
            {
                bool res = ChartValues.TryAdd(detail.Treat, 1);
                if (!res)
                    ChartValues[detail.Treat]++;
            }
        }

    }
}
