

using System.ComponentModel.DataAnnotations;

namespace Calculation_Tool.Models
{
    public enum VehicleType
    {
        Common,
        Luxury
    }
    public class VehicleModel
    {
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 0.")]
        public decimal BasePrice { get; set; }
        public VehicleType VehicleType { get; set; }
        public string? Type { get; set; }
        public decimal BasicBuyerFee { get; set; }
        public decimal SellersSpecialFee { get; set; }
        public decimal AssociationCost { get; set; }
        public decimal StorageFee { get; set; } = 100;
        public decimal TotalCost { get; set; }
        public List<VehicleModel> History { get; set; } = new List<VehicleModel>();
        
    }

}
