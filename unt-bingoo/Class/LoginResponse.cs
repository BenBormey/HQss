using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
   public class LoginResponse
    {
        public string access_token { get; set; }
        public int userId { get; set; }
        public int outletId { get; set; }
        public static string Token;
    }
}
