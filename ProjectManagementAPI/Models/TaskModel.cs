namespace ProjectManagementAPI.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long TimeSpent { get; set; }

        public int ProjectId { get; set; }
    }
}