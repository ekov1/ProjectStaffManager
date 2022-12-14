using Microsoft.EntityFrameworkCore;
using ProjectStaffManager.Data;
using ProjectStaffManager.Models.Entities;
using ProjectStaffManager.Models.ViewModels;
using ProjectStaffManager.Services.Interfaces;

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
                context.ProjectStaffMembers.AddRange(projectStaffMembers);
                var result = await context.SaveChangesAsync();

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<GridViewModel> GetAll()
        {
            var projectStaffMembers = context.ProjectStaffMembers
                  .Include(x => x.Project)
                  .Include(x => x.StaffMember)
                  .OrderBy(x => x.ProjectId).ThenByDescending(x => x.DaysWorked)
                  .ToList();
            var result = FindPairsEmployees(projectStaffMembers);
            return result;
        }

        public List<GridViewModel> FindPairsEmployees(List<ProjectStaffMember> data)
        {
            var projectIds = data.DistinctBy(x => x.Project.ProjectId).Select(x => x.Project.ProjectId).ToList();
            var list = new List<GridViewModel>();

            GridViewModel gridViewModel = new GridViewModel();

            foreach (var item in projectIds)
            {
                var bestTwo = data.Where(x => x.Project.ProjectId == item).Take(2).ToList();
                gridViewModel.ProjectId = item;

                gridViewModel.FirstStaffmemberId = bestTwo[0].StaffMember.StaffMemberId;
                gridViewModel.DaysWorkedFirstStaffmember = bestTwo[0].DaysWorked;

                if (bestTwo.Count > 1)
                {
                    gridViewModel.SecondStaffMemberId = bestTwo[1].StaffMember.StaffMemberId;
                    gridViewModel.DaysWorkedSecondStaffMember = bestTwo[1].DaysWorked;
                }

                list.Add(gridViewModel);
                gridViewModel = new GridViewModel();
            }

            return list;
        }
    }
}
