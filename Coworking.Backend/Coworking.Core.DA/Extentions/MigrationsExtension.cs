using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.Core.DA.Extentions
{
    public static class MigrationsExtension
    {
        public static readonly ManualResetEventSlim Starter = new ManualResetEventSlim(false);

        public static void EnsureMigrations(this WebApplication app, bool justPauseIfneeded)
        {

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<CoworkingDbContext>();
                var logger = services.GetRequiredService<ILogger<CoworkingDbContext>>();
                if (justPauseIfneeded)
                {
                    var migrator = context.GetService<IMigrator>();
                    var history = context.GetService<IHistoryRepository>();
                    var applied = history.GetAppliedMigrations();


                    // [!] нужно простыню pending скриптов брать и каскадом раскатывать
                    //     положил в контроллер рядом с твоим методом
                    //     без промежуточных шагов - может (а скорее точно) будет ошибка
                    //
                    //     у меня локально не проходит 20231124173715_add_Outgoing_Status
                    //     в логах на старте - migrations failed, но проверка пройдена
                    //     ensure не отработал
                    //
                    string? migration = applied.Any() ? applied.Last()?.MigrationId : null;

                    if (!string.IsNullOrEmpty(migrator.GenerateScript(migration, null)))
                    {
                        logger.LogWarning("Требуется миграция БД. Запросите скрипт через GET /service/migrations/update-script.");
                        logger.LogWarning("Сделайте POST на /service/migrations/complete для полноценного запуска сервиса.");
                        Starter.Reset();
                        Starter.Wait();
                        return;
                    }

                    return;
                }



                try
                {
                    logger.LogWarning("Migrations - Start process");
                    Starter.Reset();
                    context.Database.Migrate();
                    Starter.Set();
                    logger.LogWarning("Migrations - SUCCESS");
                }
                catch (Exception ex)
                {
                    logger.LogWarning("Migrations - Failed to apply migrations: {Message}", ex.Message);
                }
            }
        }
    }
}
