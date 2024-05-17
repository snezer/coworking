using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Core.DA.Settings
{
    public class DatabaseOptions
    {
        public string DbConnectionString { get; set; } = null!;

        [JsonProperty(Required = Required.Default)]
        public int? MaxRetryCount { get; set; } = 5;

        [JsonProperty(Required = Required.Default)]
        public TimeSpan? MaxRetryDelay { get; set; } = TimeSpan.FromSeconds(30);

        [JsonProperty(Required = Required.Default)]
        public bool? LogQueries { get; set; } = false;
    }


    public class DatabaseOptionsConfiguration : IConfigureOptions<DatabaseOptions>
    {
        private readonly IConfiguration _configuration;

        public DatabaseOptionsConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(DatabaseOptions options) =>
            options.DbConnectionString = _configuration.GetConnectionString("DefaultConnection");

    }
}
