using System;
using System.Collections.Generic;
using ProjectManagementAPI.Controllers;

namespace ProjectManagementAPI.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public long TimeSpent { get; set; }
        public string Description { get; set; }
        public IEnumerable<TaskModel> Tasks { get; set; }
    }
}