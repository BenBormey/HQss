using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
    public class RoleItem
    {
        public int Id { get; set; }

        public string RoleCode { get; set; }

        public string RoleName { get; set; }

        public string Description { get; set; }

        public bool IsSystemRole { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }


}
