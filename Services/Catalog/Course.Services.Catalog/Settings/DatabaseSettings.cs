namespace Courses.Services.Catalog.Settings
{
    /*
        Reaching setttings over a class is
        called as Options Pattern
        IOptions<DatabaseSettings> options injected on constructor
    */
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CourseCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

