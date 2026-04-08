using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
    public class ProductStockModel
    {
        public int StockID { get; set; }
        public int ProductID { get; set; }
        public int BranchId { get; set; }
        public int OutletId { get; set; }
        public int StockQty { get; set; }

        public string ProductName { get; set; }
        public string BranchName { get; set; }
        public string OutletName { get; set; }

      
    }

}
