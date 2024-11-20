using static Calculation.Common.Common;

namespace Calculation.Contract.Response
{
    public class CalculationResponse
    {
        public decimal BasePrice { get; set; }
        public VehicleType Type { get; set; }
        public decimal BasicBuyerFee { get; set; }
        public decimal SellersSpecialFee { get; set; }
        public decimal AssociationCost { get; set; }
        public decimal StorageFee { get { return 100; } }
        public decimal TotalCost { get; set; }
    }
}
