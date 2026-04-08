using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class.Report
{
  public  class SalesReportDto
    {
        public int OutletId { get; set; }

        public string OutletName { get; set; } = "";

        public DateTime SaleDate { get; set; }

        public int TotalOrders { get; set; }

        public int TotalQty { get; set; }

        public decimal GrossAmount { get; set; }

        public decimal TotalDiscount { get; set; }

        public decimal NetAmount { get; set; }
        public string InvoiceNo { get; set; }

    }
}
