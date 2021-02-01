namespace ProjectManagementAPI.Models
{
    public class CreateTaskModel
    {
        public string Name { get; set; }
        public long TimeSpent { get; set; }

        public int ProjectId { get; set; }
    }
}