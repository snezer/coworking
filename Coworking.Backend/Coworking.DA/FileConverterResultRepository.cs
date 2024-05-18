using Coworking.Core.DA;
using Coworking.DA.Interfaces;
using Coworking.DA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.DA
{
    public class FileConverterResultRepository : IFileConverterResultRepository
    {

        private readonly CoworkingDbContext? _dbContext;
        ILogger<FileConverterResultRepository> _logger;

        public Exception? OperationError { get; set; } = null;

        public FileConverterResultRepository( CoworkingDbContext dbContext, ILogger<FileConverterResultRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<FileConverterResult> LoadConvertionResultByFloorId(int floorId)
        {
            FileConverterResult result = await _dbContext.FileConverterResults.FirstOrDefaultAsync(x => x.FloorId == floorId);
            return result;
        }

        public async Task<bool> SaveConvertResult(FileConverterResult converterResult)
        {
            _logger.LogInformation("Сохранение результатов конвертации...");
            OperationError = null;
            try
            {
                await _dbContext.AddAsync(converterResult);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception err)
            {
                _logger.LogError(err, $"Сохранение прошло с ошибкой: {err.Message}");
                OperationError = err;
                return false;
            }
        }
    }
}
