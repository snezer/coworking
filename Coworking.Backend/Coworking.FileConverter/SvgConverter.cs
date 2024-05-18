using Coworking.FileConverter.Interfaces;
using Coworking.FileConverter.Models;
using Settings = Coworking.FileConverter.Models.Settings;
using GroupDocs.Conversion;
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
        private readonly Settings.ConverterSettings? _settings;

        public SvgConverter(Settings.ConverterSettings settings, ILogger<SvgConverter> logger)
        {
            _logger = logger;
            _settings = settings;
        }

        public async Task<FileConvertResultDTO> Convert(ConvertRequestDTO requestDTO)
        {
            var tempMetadata = GenFileMetadata(_settings);

            using (Stream fileStream = new FileStream(tempMetadata.FileInFullPath, FileMode.Create))
            {
                await requestDTO.FloorLauoutContext.CopyToAsync(fileStream);
            }

            FluentConverter.Load(tempMetadata.FileInFullPath).ConvertTo(tempMetadata.FileOutFullPath).Convert();

            return new FileConvertResultDTO
            {
                FloorId = requestDTO.FloorId,
                FloorLayoutContent = await LoaadSVG(tempMetadata.FileOutFullPath),
                ContentType = "base64"
            };
        }

        async Task<string> LoaadSVG(string filePath)
        {
            return System.Convert.ToBase64String(await File.ReadAllBytesAsync(filePath));
        }

        TempFileMetadata GenFileMetadata(Settings.ConverterSettings? settings)
        {

            var dirInfoIn = new DirectoryInfo(settings.IncomingTempStoragePath);
            var dirInfoOut = new DirectoryInfo(settings.OutgoingTempStoragePath);

            _logger.LogInformation("Если папок нет пытаемся их создать");

            CreateTempDirectory(dirInfoIn, settings.IncomingTempStoragePath);
            CreateTempDirectory(dirInfoOut, settings.OutgoingTempStoragePath);

            TempFileMetadata? result = new()
            {
                FileInFullPath = Path.Combine(settings.IncomingTempStoragePath, $"in_file_{Guid.NewGuid()}.png"),
                FileOutFullPath = Path.Combine(settings.OutgoingTempStoragePath, $"out_file_{Guid.NewGuid()}.svg")
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
