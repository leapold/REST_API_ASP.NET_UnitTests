using Calculation.Application.Model;
using Calculation.Contract.Response;
using static Calculation.Common.Common;

namespace Calculation.API.Mapping
{
    // This class will be in use when extra mapping needed(working with db and more...)
    public static class ContractMapping
    {
        public static CalculationResponse MapToVehicleResponse(this Vehicle vehicle)
        {
            return new CalculationResponse
            {
                AssociationCost = vehicle.AssociationCost,
                BasePrice = vehicle.BasePrice,
                BasicBuyerFee = vehicle.BasicBuyerFee,
                SellersSpecialFee = vehicle.SellersSpecialFee,
                TotalCost = vehicle.TotalCost,
                Type = (VehicleType)vehicle.Type
            };
        }
    }
}
