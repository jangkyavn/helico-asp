namespace Data.Entities
{
    public class Permission
    {
        public string RoleId { get; set; }
        public string FunctionId { get; set; }
        public string ActionId { get; set; }

        public Role Role { get; set; }
        public Function Function { get; set; }
        public Action Action { get; set; }
    }
}
