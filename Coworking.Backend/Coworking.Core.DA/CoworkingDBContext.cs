using Coworking.Core.DA.Settings;
using Coworking.Models;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;
using Serilog;
namespace Coworking.Core.DA
{
    //public class ApplicationDbContext: DbContext, IPersistedGrantDbContext
    public class CoworkingDbContext : DbContext
    {
        protected string? _connectionString { get; private set; }
        private readonly ILogger<CoworkingDbContext>? _logger;
        private readonly IOptions<DatabaseOptions>? _db_options;

        public CoworkingDbContext()
        {

        }

        public CoworkingDbContext(
            DbContextOptions<CoworkingDbContext> options,
            IOptions<DatabaseOptions> db_options,
            ILogger<CoworkingDbContext> logger) : base(options)
        {
            _db_options = db_options;
            _connectionString = _db_options.Value.DbConnectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException(nameof(_connectionString));
            }

            _logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string sCurrentDirectory = Environment.CurrentDirectory;
                //string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\Api\appsettings.json");
                //string sFilePath = Path.GetFullPath(sFile);

                var configBuilder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    //.AddJsonFile(sFilePath)
                    .Build();

                _connectionString = configBuilder.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(_connectionString))
                {
                    throw new ArgumentNullException(nameof(_connectionString));
                }
            }

            optionsBuilder
                .UseNpgsql(_connectionString, optionsBuilder =>
                {
                    var maxRetryCount = _db_options?.Value?.MaxRetryCount ?? 5;
                    var timeSpan = _db_options?.Value?.MaxRetryDelay ?? TimeSpan.FromSeconds(30);

                    optionsBuilder.EnableRetryOnFailure(
                        maxRetryCount,
                        timeSpan,
                        null); // <- error codes

                    optionsBuilder.MigrationsHistoryTable("__EFMigrationsHistory", "public");
                    optionsBuilder.MigrationsAssembly(typeof(CoworkingDbContext).Assembly.GetName().Name);
                });
                //.UseSnakeCaseNamingConvention();


            if (_db_options?.Value?.LogQueries ?? false)
            {
                optionsBuilder
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
                    .LogTo(Log.Logger.Information, LogLevel.Information, null);
            }

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder
                .HasDefaultSchema("public")
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
