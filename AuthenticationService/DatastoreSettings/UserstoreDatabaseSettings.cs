namespace AuthenticationService.DatastoreSettings
{
    public class UserstoreDatabaseSettings
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    
    public interface IUserstoreDatabaseSettings
    {
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}