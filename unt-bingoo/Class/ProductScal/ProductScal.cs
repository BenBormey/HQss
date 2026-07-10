using System;

namespace unt_bingoo.Class.ProductScal
{
    public class ProductScal
    {
        public int Id { get; set; }

        public decimal ProId { get; set; }

        //public double? CTNPerPallet { get; set; }

        //public string UOM { get; set; }

        public double? Width { get; set; }
        public string ProNumY { get; set; }

        public double? Length { get; set; }

        public double? Height { get; set; }

        public double? CBMPerCTN { get; set; }
        public string UOMCode { get; set; }
        //public string UOMName { get; set; }
        public double? NetWeight { get; set; }

        public double? GrossWeight { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public ProductScal()
        {
            UOMCode = string.Empty;
            CreatedDate = DateTime.Now;
            Status = true;
        }
    }
}