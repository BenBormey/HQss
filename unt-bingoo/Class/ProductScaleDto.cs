using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
   public class ProductScaleDto
    {
        public decimal? CTNPerPallet { get; set; }

        public string UOMCode { get; set; }

        public decimal? Width { get; set; }

        public decimal? Length { get; set; }

        public decimal? Height { get; set; }

        public decimal? CBMPerCTN { get; set; }

        public decimal? NetWeight { get; set; }

        public decimal? GrossWeight { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool Status { get; set; }
    }
}
