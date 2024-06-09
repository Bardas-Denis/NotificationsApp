using MongoDB.Driver;
using NewsApi.Models;
using NewsApi.Settings;

namespace NewsApi.Services
{
    public class AnnouncementCollectionService : IAnnouncementCollectionService
    {
        private readonly IMongoCollection<Announcement> _announcements;

        public AnnouncementCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _announcements = database.GetCollection<Announcement>(settings.AnnouncementsCollectionName);
        }


        public async Task<bool> Create(Announcement model)
        {
            model.Id = Guid.NewGuid();
            await _announcements.InsertOneAsync(model);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result =await _announcements.DeleteOneAsync(a => a.Id == id);
            if (!result.IsAcknowledged || result.DeletedCount == 0)
            {
                return false;
            }
            return true;

        }

        public async Task<Announcement> Get(Guid id)
        {

            var announcement = await _announcements.FindAsync(a => a.Id == id);
            return announcement.FirstOrDefault();
        }

        public async Task<List<Announcement>> GetAll()
        {
            var result = await _announcements.FindAsync(announcement => true);
            return result.ToList();
        }

        public async Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId)
        {
            var announcementsByCategoryId =await _announcements.FindAsync(a => a.CategoryId == categoryId);
            return announcementsByCategoryId.ToList();
        }

        public async Task<bool> Update(Guid id, Announcement model)
        {
            model.Id = id;
            var updateResult =await _announcements.ReplaceOneAsync(a => a.Id == id,model);
            if(updateResult.ModifiedCount == 0 && updateResult.IsAcknowledged==false)
            {
               await _announcements.InsertOneAsync(model);
            }
            return (updateResult.IsAcknowledged && updateResult.ModifiedCount>0);
        }
    }
}
