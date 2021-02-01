﻿using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementAPI.Data
{
    public class ProjectManagementContext : DbContext
    {
        public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
    }
}
