namespace unt_bingoo.Class
{
    public class PermissionItem
    {
        public int Id { get; set; }
        public string PermissionCode { get; set; }
        public string PermissionName { get; set; }
        public string Remark { get; set; }

        public override string ToString()
        {
            return PermissionName;
        }
    }
}
