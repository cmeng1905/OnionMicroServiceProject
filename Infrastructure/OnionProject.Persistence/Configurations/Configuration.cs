using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Configurations
{
    public static class Configuration
    {
        static public string MssqlConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/OnionArchitecture.API"));
                configurationManager.AddJsonFile($"appsettings.json");
                var appSettings = configurationManager.Get<AppSettings>();
                return appSettings.MssqlConnStr;
            }
        }
    }
}
