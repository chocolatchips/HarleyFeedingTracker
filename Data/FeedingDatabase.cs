using HarleyFeedingTracker.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarleyFeedingTracker.Data
{
    public class FeedingDatabase
    {
        SQLiteAsyncConnection Database;

        public FeedingDatabase()
        {
        }

        private async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DBConstants.DatabasePath, Constants.DBConstants.Flags);            
            var result = await Database.CreateTablesAsync<FoodBrand, FlavourItem, FeedingDetails>();
        }

        public async Task<List<FoodBrand>> GetAllBrandsAsync()
        {
            await Init();
            return await Database.Table<FoodBrand>().ToListAsync();
        }

        public async Task<bool> FindBrandAsync(string brand)
        {
            await Init();
            return await Database.Table<FoodBrand>().Where(b => b.Name == brand).FirstOrDefaultAsync() != null;
        }

        public async Task<int> AddFlavourItemAsync(FlavourItem flavourItem)
        {
            ArgumentNullException.ThrowIfNull(flavourItem, nameof(flavourItem));
            await Init();

            return await Database.InsertAsync(flavourItem);
        }

        public async Task<List<FlavourItem>> GetAllFlavoursAsync()
        {
            await Init();

            return await Database.Table<FlavourItem>().ToListAsync();
        }

        public async Task<List<FlavourItem>> GetFlavoursForBrandAsync(FoodBrand brand)
        {
            ArgumentNullException.ThrowIfNull(brand, nameof(brand));
            await Init();

            return await Database.Table<FlavourItem>().Where(f => f.Brand == brand.Name).ToListAsync();
        }

        public async Task<List<FoodBrand>> GetDistinctBrandsAsync()
        {
            await Init();
            return await Database.QueryAsync<FoodBrand>("SELECT DISTINCT * from brands");
        }

        public async Task<List<FlavourItem>> GetDistinctFlavoursAsync()
        {
            await Init();
            return await Database.QueryAsync<FlavourItem>("SELECT DISTINCT * from brandflavours");
        }

        public async Task<List<FeedingDetails>> GetDetailsAsync()
        {
            await Init();
            return await Database.Table<FeedingDetails>().ToListAsync();
        }



        public async Task<int> AddBrandAsync(FoodBrand brand)
        {
            ArgumentNullException.ThrowIfNull(brand, nameof(brand));
            await Init();

            if (await FindBrandAsync(brand.Name))
                return await Database.UpdateAsync(brand);

            else
                return await Database.InsertAsync(brand);
        }


        public async Task<int> AddFeedingDetails(FeedingDetails feedingDetails)
        {
            ArgumentNullException.ThrowIfNull(feedingDetails, nameof(feedingDetails));
            await Init();
            return await Database.InsertAsync(feedingDetails);
        }


        public async Task<int> DeleteBrandAsync(FoodBrand brand)
        {
            await Init();
            return await Database.DeleteAsync(brand);
        }

        public async Task<int> DeleteFlavourAsync(FlavourItem flavour)
        {
            await Init();
            return await Database.DeleteAsync(flavour);
        }

        public async Task<int> ClearTable<T>() where T : class
        {
            await Init();
            return await Database.DeleteAllAsync<T>();
        }
    }
}
