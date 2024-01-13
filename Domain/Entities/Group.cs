namespace Domain.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }

        public int ModuleId { get; set; }

        public virtual Module? Module { get; set; }
    }
}
