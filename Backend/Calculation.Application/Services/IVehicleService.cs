using Calculation.Application.Model;
using static Calculation.Common.Common;

namespace Calculation.Application.Services
{
    public interface IVehicleService
    {
        Task<Vehicle> CalculateFees(decimal basePrice, VehicleType type, CancellationToken token = default);
    }
}
