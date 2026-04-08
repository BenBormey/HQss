using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
  public  class CashPaymentDto
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public decimal CashReceived { get; set; }
    }
}
