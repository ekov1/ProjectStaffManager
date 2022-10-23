using Microsoft.AspNetCore.Mvc;
using ProjectStaffManager.Models.Entities;
using ProjectStaffManager.Services.Interfaces;

namespace ProjectStaffManager.Web.Controllers
{
    public class ProjectStaffMemberController : Controller
    {
        private readonly IProjectStaffMemberService ProjectStaffMemberService;

        public ProjectStaffMemberController(IProjectStaffMemberService projectStaffMemberService)
        {
            this.ProjectStaffMemberService = projectStaffMemberService;
        }

        public IActionResult Index()
        {
            var model = ProjectStaffMemberService.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(IFormFile file)
        {
            try
            {
                List<ProjectStaffMember> projectStafMembers = new List<ProjectStaffMember>();
                List<Project> projects = new List<Project>();
                List<StaffMember> staffMembers = new List<StaffMember>();
                var filePath = Path.GetTempFileName();

                if (file != null)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    using (var reader = System.IO.File.OpenText(filePath))
                    {
                        while (!reader.EndOfStream)
                        {
                            string[] lineParts = reader.ReadLine().Split(", ");

                            int staffMemberId = int.Parse(lineParts[0]);
                            int projectId = int.Parse(lineParts[1]);

                            if (!projects.Any(x => x.ProjectId == projectId))
                            {
                                projects.Add(new Project() { ProjectId = projectId });
                            }

                            if (!staffMembers.Any(x => x.StaffMemberId == staffMemberId))
                            {
                                staffMembers.Add(new StaffMember() { StaffMemberId = staffMemberId });
                            }



                            ProjectStaffMember projectStaffMember = new ProjectStaffMember()
                            {
                                Project = projects.FirstOrDefault(x => x.ProjectId == projectId),
                                StaffMember = staffMembers.FirstOrDefault(x => x.StaffMemberId == staffMemberId),
                                StaffMemberId = staffMembers.FirstOrDefault(x => x.StaffMemberId == staffMemberId).StaffMemberId,
                                ProjectId = projects.FirstOrDefault(x => x.ProjectId == projectId).ProjectId,
                                DateFrom = DateTime.Parse(lineParts[2]),
                                DateTo = lineParts[3] != "NULL" ? DateTime.Parse(lineParts[3]) : (DateTime?)null
                            };

                            DateTime? end = projectStaffMember.DateTo == null ? DateTime.Today : projectStaffMember.DateTo;

                            projectStaffMember.DaysWorked = (int?)(end - projectStaffMember.DateFrom).Value.TotalDays;

                            projectStafMembers.Add(projectStaffMember);
                        }
                    }
                }

                if (ProjectStaffMemberService.Create(projectStafMembers).Result)
                {
                    ViewBag.Message = "File Upload Successful";
                }
                else
                {
                    ViewBag.Message = "File Upload Failed";
                }
            }
            catch (Exception ex)
            {
                //Log ex
                ViewBag.Message = "File Upload Failed";
            }
            return RedirectToAction("Index");
        }
    }
}
