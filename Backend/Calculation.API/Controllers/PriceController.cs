using Calculation.API.Mapping;
using Calculation.Application.Model;
using Calculation.Application.Services;
using Calculation.Contract.Request;
using Calculation.Contract.Response;
using Microsoft.AspNetCore.Mvc;
using static Calculation.Common.Common;

namespace Calculation.API.Controllers
{
    [ApiController]

    public class PriceController : ControllerBase
    {

        private readonly ILogger<PriceController> _logger;

        IVehicleService _vehicleCalculator;
        public PriceController(IVehicleService vehicleCalculator, ILogger<PriceController> logger)
        {
            _logger = logger;
            _vehicleCalculator = vehicleCalculator;
        }

        [HttpPost(ApiEndpoints.CalculatePrice)]
        public async Task<IActionResult> Price([FromBody] CalculationRequest request, CancellationToken token)
        {
            try
            {
                VehicleType vehicleType;
                if (Enum.TryParse(request.Type, true, out vehicleType))
                {
                    if (request.BasePrice > 0)
                    {
                        var updatedPrice = await _vehicleCalculator.CalculateFees(request.BasePrice, vehicleType, token);
                        var response = updatedPrice.MapToVehicleResponse();
                        return Ok(response);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, new { Message = "Can not calculate the price when base braci less equal zero." });
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Can not calculate the price." });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Can not calculate the price." });
            }
        }
    }
}
