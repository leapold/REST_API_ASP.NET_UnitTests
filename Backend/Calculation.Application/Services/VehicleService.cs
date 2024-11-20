using Calculation.Application.Model;
using static Calculation.Common.Common;

namespace Calculation.Application.Services
{
    public class VehicleService : IVehicleService
    {
        private const short storageFee = 100;

        public async Task<Vehicle> CalculateFees(decimal basePrice, VehicleType type, CancellationToken token = default)
        {
            var basicBuyerFeeTask = Task.Run(() => CalculateBasicBuyerFee(basePrice, type));
            var sellersSpecialFeeTask = Task.Run(() => CalculateSellersSpecialFee(basePrice, type));
            var associationCostTask = Task.Run(() => CalculateAssociationFee(basePrice));
            await Task.WhenAll(basicBuyerFeeTask, sellersSpecialFeeTask, associationCostTask);

            var basicBuyerFee = basicBuyerFeeTask.Result;
            var sellersSpecialFee = sellersSpecialFeeTask.Result;
            var associationCost = associationCostTask.Result;

            var totalCost = basePrice + basicBuyerFee + sellersSpecialFee + associationCost + storageFee;

            Vehicle vehicle = new()
            {
                BasePrice = basePrice,
                BasicBuyerFee = basicBuyerFee,
                AssociationCost = associationCost,
                TotalCost = totalCost,
                SellersSpecialFee = sellersSpecialFee,
                Type = type,
                StorageFee = storageFee
            };

            return vehicle;
        }

        private decimal CalculateBasicBuyerFee(decimal price, VehicleType type, CancellationToken token = default)
        {
            decimal fee = price * 0.10m;

            if (type == VehicleType.Common)
            {
                fee = Math.Clamp(fee, 10, 50);
            }
            else if (type == VehicleType.Luxury)
            {
                fee = Math.Clamp(fee, 25, 200);
            }

            return fee;
        }

        private decimal CalculateSellersSpecialFee(decimal price, VehicleType type)
        {
            return type == VehicleType.Luxury ? price * 0.04m : price * 0.02m;
        }

        private decimal CalculateAssociationFee(decimal price)
        {
            if (price < 0)
            {
                return 0;
            }
            else if (price > 0 && price <= 500)
            {
                return 5;
            }
            else if (price <= 1000)
            {
                return 10;
            }
            else if (price <= 3000)
            {
                return 15;
            }
            else
            {
                return 20;
            }
        }

        
    }
}
