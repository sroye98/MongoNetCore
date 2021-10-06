using System;
namespace MongoNetCore.Application.Settings
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class DatabaseSettings : IDatabaseSettings
    {
        public DatabaseSettings()
        {
        }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
