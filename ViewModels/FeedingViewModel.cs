using HarleyFeedingTracker.Data;
using HarleyFeedingTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.ViewModels
{
    public class FeedingViewModel
    {
        private readonly FeedingDatabase _database;
        private string _selectedBrand = string.Empty;
        private string _selectedFlavour = string.Empty;
        private string _selectedTreat = string.Empty;

        public ObservableCollection<FoodBrand> Brands { get; set; }
        public ObservableCollection<FlavourItem> Flavours {  get; set; }

        public string SelectedBrand
        {
            get => _selectedBrand;
            set
            {
                _selectedBrand = value;
                OnPropertyChanged(nameof(SelectedBrand));
            }
        }

        public string SelectedFlavour
        {
            get => _selectedFlavour;
            set
            {
                _selectedFlavour = value;
                OnPropertyChanged(nameof(SelectedFlavour));
            }
        }

        public string SelectedTreat
        {
            get => _selectedTreat;
            set
            {
                _selectedTreat = value;
                OnPropertyChanged(nameof(SelectedTreat));
            }
        }

        public FeedingViewModel(FeedingDatabase feedingDatabase)
        {
            Brands = new ObservableCollection<FoodBrand>();
            Flavours = new ObservableCollection<FlavourItem>();
            _database = feedingDatabase;

            
            LoadBrands();
            LoadFlavours();
            //FirstTimeSetup();
        }

        private void FirstTimeSetup()
        {
            if (Brands.Count == 0)
            {
                FoodBrand b = new()
                {
                    Name = "Acana"
                };
                AddNewBrand(b);

                FoodBrand b2 = new()
                {
                    Name = "Other"
                };
                AddNewBrand(b2);
            }

            if (Flavours.Count == 0)
            {
                FlavourItem f1 = new()
                {
                    Brand = "Acana",
                    Flavour = "Beef"
                };
                AddNewFlavour(f1);

                FlavourItem f2 = new()
                {
                    Brand = "Acana",
                    Flavour = "Chicken"
                };
                AddNewFlavour(f2);
            }
        }

        private async void AddNewBrand(FoodBrand newBrand)
        {
            await _database.AddBrandAsync(newBrand);
            LoadBrands();
        }

        private async void AddNewFlavour(FlavourItem newFlavour)
        {
            await _database.AddFlavourItemAsync(newFlavour);
            LoadFlavours();
        }


        private async void LoadFlavours()
        {
            //var flav = await _database.GetAllFlavoursAsync();
            var flav = await _database.GetDistinctFlavoursAsync();
            Flavours.Clear();
            foreach (var flavour in flav)
            {
                Flavours.Add(flavour);
            }
        }

        private async void LoadBrands()
        {
            //var brands = await _database.GetAllBrandsAsync();
            var brands = await _database.GetDistinctBrandsAsync();
            Brands.Clear();
            foreach (var brand in brands)
            {
                Brands.Add(brand);
            }
        }

        private async void ClearBrands()
        {
            await _database.ClearTable<FoodBrand>();
        }

        private async void ClearFlavours()
        {
            await _database.ClearTable<FlavourItem>();
        }

        private void ClearTables()
        {
            ClearBrands();
            ClearFlavours();
        }


        public async Task<int> SaveFeeding()
        {
            if (SelectedBrand == string.Empty || SelectedFlavour == string.Empty || SelectedTreat == string.Empty)
                return 0;

            FeedingDetails details = new()
            {
                Brand = SelectedBrand,
                Flavour = SelectedFlavour,
                Treat = SelectedTreat,
                Date = DateTime.Now
            };

            return await _database.AddFeedingDetails(details);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
