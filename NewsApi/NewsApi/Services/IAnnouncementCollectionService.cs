using NewsApi.Models;

namespace NewsApi.Services
{
    public interface IAnnouncementCollectionService: ICollectionService<Announcement>
    {
        public Task<List<Announcement>> GetAnnouncementsByCategoryId(string categoryId);
    }
}
