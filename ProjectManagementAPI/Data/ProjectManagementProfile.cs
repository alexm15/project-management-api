using AutoMapper;
using ProjectManagementAPI.Controllers;
using ProjectManagementAPI.Data.Entitites;
using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Data
{
    public class ProjectManagementProfile : Profile
    {
        public ProjectManagementProfile()
        {
            CreateMap<Project, ProjectModel>();
            CreateMap<ProjectTask, TaskModel>();
            CreateMap<CreateProjectModel, Project>();
        }
    }
}