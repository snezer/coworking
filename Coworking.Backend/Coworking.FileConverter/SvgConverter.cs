using Coworking.FileConverter.Interfaces;
using Coworking.FileConverter.Models;
using Coworking.FileConverter.Models.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Runtime;

namespace Coworking.FileConverter
{
    internal class TempFileMetadata
    {
        public string? FileInFullPath { get; set; }
        public string? FileOutFullPath { get; set; }
    }

    public class SvgConverter : ISvgConverter
    {
        private readonly ILogger<SvgConverter> _logger;
        private readonly ConverterSettings? _settings;

        public SvgConverter(ConverterSettings settings, ILogger<SvgConverter> logger)
        {
            _logger = logger;
            _settings = settings;
        }

        public FileConvertResultDTO Convert(ConvertRequestDTO requestDTO)
        {
            var tempMetadata = GenFileMetadata(_settings);

            FluentConverter.Load().ConvertTo().Convert();            
        }

        TempFileMetadata GenFileMetadata(ConverterSettings? settings)
        {

            var dirInfoIn = new DirectoryInfo(settings.IncomingTempStoragePath);
            var dirInfoOut = new DirectoryInfo(settings.OutgoingTempStoragePath);

            _logger.LogInformation("Если папок нет пытаемся их создать");

            CreateTempDirectory(dirInfoIn, settings.IncomingTempStoragePath);
            CreateTempDirectory(dirInfoOut, settings.OutgoingTempStoragePath);

            TempFileMetadata? result = new()
            {
                FileInFullPath = settings.IncomingTempStoragePath + $"in_file_{Guid.NewGuid()}.png",
                FileOutFullPath = settings.OutgoingTempStoragePath + $"out_file_{Guid.NewGuid()}.svg"
            };

            return result;
        }

        void CreateTempDirectory(DirectoryInfo directory, string path)
        {
            if (!directory.Exists)
            {
                try
                {
                    _logger.LogInformation("Пытаемся создать папку...");
                    Directory.CreateDirectory(path);
                }
                catch (System.Exception err)
                {
                    _logger.LogError(err, $"При создании каталога произошла ошибка: {err.Message}");
                    throw;
                }

            }
        }
    }
}
