using System;

namespace unt_bingoo.Class
{
    public class ProductDeliveryLogisticItem
    {
        public int Id { get; set; }
        public string ProNumY { get; set; }
        public int ProvinceId { get; set; }
        public string ProvinceNameEN { get; set; }
        public decimal AdditionalCost { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
