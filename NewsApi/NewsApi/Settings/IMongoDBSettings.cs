namespace NewsApi.Settings
{
    public interface IMongoDBSettings
    {
        string AnnouncementsCollectionName { get; set; }
        string CategoriesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CategoriesDatabaseName { get; set; }
    }
}
