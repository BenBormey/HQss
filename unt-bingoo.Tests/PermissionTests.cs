using System;
using System.Collections.Generic;
using unt_bingoo.Controller;

namespace unt_bingoo.Tests
{
    /// <summary>
    /// APIGlobals.HasPermission is what every permission-gated form in the app
    /// calls before letting a user into a feature. It reads mutable static
    /// state (RoleCode/Permissions), so each test resets that state itself
    /// rather than relying on ordering or isolation from xUnit.
    /// </summary>
    public class PermissionTests : IDisposable
    {
        public PermissionTests()
        {
            APIGlobals.RoleCode = null;
            APIGlobals.Permissions = new List<string>();
        }

        public void Dispose()
        {
            APIGlobals.RoleCode = null;
            APIGlobals.Permissions = new List<string>();
        }

        [Fact]
        public void ADMIN_role_has_every_permission_even_without_being_granted_it()
        {
            APIGlobals.RoleCode = "ADMIN";
            APIGlobals.Permissions = new List<string>(); // deliberately empty

            Assert.True(APIGlobals.HasPermission("OUTLET_STOCK"));
        }

        [Fact]
        public void Non_admin_role_is_denied_a_permission_it_was_not_granted()
        {
            APIGlobals.RoleCode = "CASHIER";
            APIGlobals.Permissions = new List<string> { "SOME_OTHER_PERMISSION" };

            Assert.False(APIGlobals.HasPermission("OUTLET_STOCK"));
        }

        [Fact]
        public void Non_admin_role_is_allowed_a_permission_it_was_granted()
        {
            APIGlobals.RoleCode = "CASHIER";
            APIGlobals.Permissions = new List<string> { "OUTLET_STOCK" };

            Assert.True(APIGlobals.HasPermission("OUTLET_STOCK"));
        }

        [Fact]
        public void A_null_permissions_list_denies_rather_than_throws()
        {
            APIGlobals.RoleCode = "CASHIER";
            APIGlobals.Permissions = null;

            Assert.False(APIGlobals.HasPermission("OUTLET_STOCK"));
        }

        [Fact]
        public void Permission_check_is_case_sensitive_by_design()
        {
            // Documents current behavior: server-issued permission codes are
            // expected to match exactly. If this ever needs to be
            // case-insensitive, that is a deliberate behavior change, not a bug
            // fix - this test will correctly fail and force that decision to be explicit.
            APIGlobals.RoleCode = "CASHIER";
            APIGlobals.Permissions = new List<string> { "OUTLET_STOCK" };

            Assert.False(APIGlobals.HasPermission("outlet_stock"));
        }
    }
}
