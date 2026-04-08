using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
  public  class QrConfirmDto
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionNo { get; set; }
    }
}
