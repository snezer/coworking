using Coworking.Core.DA;
using Coworking.Core.DA.Settings;
using Coworking.Infrastructure;
using Coworking.Models;
using IdentityModel;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prometheus;
using Serilog;
using System.Text;
using Coworking.Core.DA.Extentions;
using Coworking.Extentions;
using Coworking.FileConverter.Models.Settings;
using Coworking.FileConverter.Interfaces;
using Coworking.FileConverter;


var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment}.json", true)
    .AddEnvironmentVariables()
    .Build();

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var services = builder.Services;

services.Configure<DatabaseOptions>(config.GetSection(nameof(DatabaseOptions)));

string? connSection = config.GetConnectionString("DefaultConnection");
services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connSection));
services.AddHealthChecks().AddNpgSql(connSection).ForwardToPrometheus();
services.AddInfrastructure(config);
services.AddServiceOptions<ConverterSettings>(config, "ConverterSettings");


services.AddDefaultIdentity<ApplicationUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;

            options.ClaimsIdentity.UserIdClaimType = JwtClaimTypes.Subject;
            options.ClaimsIdentity.UserNameClaimType = JwtClaimTypes.Name;
            //options.ClaimsIdentity.RoleClaimType = JwtClaimTypes.Role;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

services.AddIdentityServer()
        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
        .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
        .AddInMemoryClients(IdentityServerConfig.GetClients());

services.AddAuthentication()
    .AddIdentityServerJwt();

services.AddAuthorization(options =>
{
    foreach (var claim in KnownClaims.Claims)
    {
        options.AddPolicy(claim.Value, policy => policy.RequireClaim(claim.Value));
    }
});

services.AddScoped<ClaimsLoader>();
services.AddSingleton<ISvgConverter, SvgConverter>();

services.Configure<JwtSettings>(config.GetSection("JwtSettings"));
services.Configure<JwtBearerOptions>(IdentityServerJwtConstants.IdentityServerJwtBearerScheme,
    options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:SecretKey"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Host
        .UseSerilog((hostBuilderContext, loggerConfiguration) =>
        {
            loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
            loggerConfiguration.Enrich.With(new LogEventEnricher());
        });
builder.Host.UseWindowsService();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.

/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    //Resolve ASP .NET Core Identity with DI help
    var userManager = (UserManager<ApplicationUser>)scope.ServiceProvider.GetService(typeof(UserManager<ApplicationUser>));
    var roleManager = scope.ServiceProvider.GetRequiredService<ClaimsLoader>();
    // do you things here

    SeedHelper.SeedAthentication(userManager, roleManager);
}
app.UseRouting();
app.MapControllers();

//var runTask = app.RunAsync(config["hostUrl"]);
var runTask = app.RunAsync();

//app.Run();
app.EnsureMigrations(config.GetValue<bool>("UseManualMigrations"));


//Log.Logger.Warning("�������� �������� �������� - ������ ������� ���������");
await runTask;



