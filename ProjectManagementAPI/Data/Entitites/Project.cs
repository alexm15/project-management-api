﻿using System;
using System.Collections.Generic;

namespace ProjectManagementAPI.Data.Entitites
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public long TimeSpent { get; set; }
        public string Description { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}
