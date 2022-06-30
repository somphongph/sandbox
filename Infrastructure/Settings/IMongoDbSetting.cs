using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Settings
{
    public interface IMongoDbSetting
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}