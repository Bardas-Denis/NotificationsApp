using MongoDB.Driver;
using NewsApi.Models;
using NewsApi.Settings;

namespace NewsApi.Services
{
    public class CategoryCollectionService : ICategoryCollectionService
    {
        private readonly IMongoCollection<Category> _categories;
        public CategoryCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.CategoriesDatabaseName);

            _categories = database.GetCollection<Category>(settings.CategoriesCollectionName);
        }
        public async Task<bool> Create(Category model)
        {
            model.Id = Guid.NewGuid();
            await _categories.InsertOneAsync(model);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _categories.DeleteOneAsync(c => c.Id == id);
            if (!result.IsAcknowledged || result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<Category> Get(Guid id)
        {
            var announcement = await _categories.FindAsync(c => c.Id == id);
            return announcement.FirstOrDefault();
        }

        public async Task<List<Category>> GetAll()
        {
            var result = await _categories.FindAsync(category => true);
            return result.ToList();
        }

        public async Task<bool> Update(Guid id, Category model)
        {
            model.Id = id;
            var updateResult = await _categories.ReplaceOneAsync(c => c.Id == id, model);
            if (updateResult.ModifiedCount == 0 && updateResult.IsAcknowledged == false)
            {
                await _categories.InsertOneAsync(model);
            }
            return (updateResult.IsAcknowledged && updateResult.ModifiedCount > 0);
        }
    }
}
