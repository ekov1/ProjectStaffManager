using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace ProjectStaffManager.Models.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public IList<ProjectStaffMember> ProjectStaffMembers { get; set; }
    }
}
