using Coworking.DA.Interfaces;
using Coworking.DA.Models;
using Coworking.FileConverter;
using Coworking.FileConverter.Interfaces;
using Coworking.FileConverter.Models;
using Coworking.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Coworking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly ILogger<ConverterController> _logger;
        private readonly ISvgConverter _svgConverter;
        private readonly IFileConverterResultRepository _converterResultRepository;

        string[] validPngFileExtensions = new string[] { ".png" };

        public ConverterController(ISvgConverter converter, IFileConverterResultRepository converterResultRepository, ILogger<ConverterController> logger)
        {
            _logger = logger;
            _svgConverter = converter;
            _converterResultRepository = converterResultRepository;
        }

        [HttpPost]
        [Route("PngSvgComnvertFile")]
        [ProducesResponseType(typeof(FileConvertResultDTO), 200)]
        public async Task<IActionResult> PngSvgComnvertFile([FromForm] ConvertRequestDTO request)
        {
            if (request.FloorLauoutContext == null)
            {
                _logger.LogInformation("Файл не был передан в метод.");
                return StatusCode(400, "Файл не был передан в метод.");
            }

            if (!validPngFileExtensions.Any(x => request.FloorLauoutContext.FileName.EndsWith(x)))
            {
                _logger.LogInformation("Формат файла не поддерживается. Требуется формат .png");
                return StatusCode(400, "Формат файла не поддерживается. Требуется формат .png");
            }

            try
            {
                var result = await _svgConverter.Convert(request);

                //TODO: Сохраняем в базу
                if (await _converterResultRepository.SaveConvertResult(new FileConverterResult 
                {
                    ContentType = result.ContentType,
                    FloorId = result.FloorId,
                    FloorLayoutContent = result.FloorLayoutContent
                })) return Ok();
                else 
                    return NotFound();
            }
            catch (Exception err)
            {
                _logger.LogError(err, $"Ошибка конвертации файла: {err.Message}");
                return StatusCode(500, err);
            }
        }

        [HttpGet]
        [Route("converted/file/{floorId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileConvertResultDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetConvertionResultByFloorId(int floorId)
        {
            var result = await _converterResultRepository.LoadConvertionResultByFloorId(floorId);
            return result is null ? NotFound() : Ok(result);
        }
    }
}
