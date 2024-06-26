namespace DTO
{
    public class Role
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleInfo { get; set; }

        public override string ToString()
        {
            return $"RoleID: {RoleID}, RoleName: {RoleName}, RoleInfo: {RoleInfo}";
        }
    }
}
