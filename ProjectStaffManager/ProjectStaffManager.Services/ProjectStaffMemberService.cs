using Microsoft.EntityFrameworkCore;
using ProjectStaffManager.Data;
using ProjectStaffManager.Models.Entities;
using ProjectStaffManager.Models.ViewModels;
using ProjectStaffManager.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ProjectStaffManager.Services
{
    public class ProjectStaffMemberService : IProjectStaffMemberService
    {
        private ApplicationDbContext context;

        public ProjectStaffMemberService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(IEnumerable<ProjectStaffMember> projectStaffMembers)
        {
            try
            {
                List<Project> projects = projectStaffMembers
                    .DistinctBy(x => x.ProjectID)
                    .Select(x => new Project()
                    { 
                        ProjectId = x.ProjectID,
                        //ProjectStaffMembers = projectStaffMembers.Where(x=>x.ProjectID == x.ProjectID).ToList(),
                    })
                    .ToList();
                List<StaffMember> staffMembers = projectStaffMembers.DistinctBy(x => x.StaffMemberID).Select(x => new StaffMember() { StaffMemberId = x.StaffMemberID }).ToList();
               
                context.Projects.AddRange(projects);
                context.StaffMembers.AddRange(staffMembers);
                context.ProjectStaffMembers.AddRange(projectStaffMembers);

                var result = await context.SaveChangesAsync();

                return result>0;
            }
            catch (Exception ex)
            {
               return false;
            }
        }

        public List<GridViewModel> GetAll()
        {
          var projectStaffMembers = context.ProjectStaffMembers
                .Include(x=>x.Project)
                .Include(x => x.StaffMember)
                .OrderBy(x => x.ProjectID).ThenBy(x => x.DaysWorked)
                .ToList();
            var result = FindPairsEmployees(projectStaffMembers);
            return result;
        }

        public List<GridViewModel> FindPairsEmployees(List<ProjectStaffMember> data)
        {
            var projects = new List<GridViewModel>();
           
            int curentProjectId;

            GridViewModel gridViewModel = new GridViewModel();

            for (int i = 0; i < data.Count; i++)
            {
                if (gridViewModel.ProjectId == null || gridViewModel.ProjectId != data[i].ProjectID)
                {
                    gridViewModel.ProjectId = data[i].Project.ProjectId;
                    gridViewModel.FirstStaffmemberId = data[i].StaffMember.StaffMemberId;

                    if (i+1<data.Count)
                    {
                        if (data[i+1].ProjectID == gridViewModel.ProjectId)
                        {
                            gridViewModel.SecondStaffMemberId = data[i].StaffMemberID;
                        }
                    }
                    projects.Add(gridViewModel);
                    gridViewModel = new GridViewModel();
                }
            }

            return projects;
        }
    }
}
