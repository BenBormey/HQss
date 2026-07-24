using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Controller
{
   public static class APIGlobals
    {
        // Standard message shown anywhere the user tries to use a function
        // their role has no permission for.
        public const string NoPermissionMessage =
            "You do not have permission to use this function!";

        public static APIsController Api;
   

        public static int UserId;
        public static int? OutletId;
        public static string Token;
        public static string UserName;
        public static string FullName;
        public static string RoleName;
        public static string RoleCode;
        public static List<string> Permissions = new List<string>();

        // MD (ADMIN) always has full access; other roles need the permission granted.
        public static bool HasPermission(string permissionCode)
        {
            return RoleCode == "ADMIN" ||
                   (Permissions != null && Permissions.Contains(permissionCode));
        }

    }
}
