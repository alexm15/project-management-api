namespace ProjectManagementAPI.Data.Entitites
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long TimeSpent { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}