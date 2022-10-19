using Microsoft.AspNetCore.Mvc;
using ProjectStaffManager.Models.Entities;
using ProjectStaffManager.Services.Interfaces;
using ProjectStaffManager.Web.Extensions;

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
                            ProjectStaffMember projectStafMember = reader.ReadLine().ToProjectStaffMember();
                            projectStafMembers.Add(projectStafMember);
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
