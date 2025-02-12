using System;
using System.Collections.Specialized;
using System.Configuration;

namespace LR_12
{
    public class AppConfig
    {
        public string DatabaseConnectionString { get; set; }
        public int MaxConnections { get; set; }
        public bool EnableLogging { get; private set; }

        public AppConfig()
        {
            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            var settings = ConfigurationManager.AppSettings;

            DatabaseConnectionString = settings["DatabaseConnectionString"];
            MaxConnections = int.Parse(settings["MaxConnections"]);
            EnableLogging = bool.Parse(settings["EnableLogging"]);
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(DatabaseConnectionString))
                throw new InvalidOperationException("DatabaseConnectionString is not set.");

            if (MaxConnections <= 0)
                throw new InvalidOperationException("MaxConnections must be greater than 0.");
        }
    }
}
