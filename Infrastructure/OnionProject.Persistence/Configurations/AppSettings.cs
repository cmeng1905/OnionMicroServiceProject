using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Configurations
{
    public class AppSettings
    {
        public string MssqlConnStr { get; set; }

        public string JWTSecret { get; set; }

    }
}
