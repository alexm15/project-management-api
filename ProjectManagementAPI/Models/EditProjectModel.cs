using System;

namespace ProjectManagementAPI.Models
{
    public class EditProjectModel
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public long TimeSpent { get; set; }
        public string Description { get; set; }
    }
}