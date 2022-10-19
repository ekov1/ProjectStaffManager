using ProjectStaffManager.Models.Entities;

namespace ProjectStaffManager.Web.Extensions
{
    public static class ProjectStaffMemberExtensions
    {
        public static ProjectStaffMember ToProjectStaffMember(this string data)
        {
            var parseData = data.Split(", ");

            try
            {
                var psm = new ProjectStaffMember
                {
                    ProjectId = int.Parse(parseData[1]),
                    StaffMemberId = int.Parse(parseData[0]),
                    //Project = new Project() { ProjectId = int.Parse(parseData[1]) },
                    //StaffMember = new StaffMember() { StaffMemberId = int.Parse(parseData[0]) },
                    DateFrom = DateTime.Parse(parseData[2]),
                    DateTo = parseData[3] != "NULL" ? DateTime.Parse(parseData[3]) : (DateTime?)null
                };

                DateTime? end = psm.DateTo == null ? DateTime.Today : psm.DateTo;

                psm.DaysWorked = (int?)(end - psm.DateFrom).Value.TotalDays;
                return psm;

            }
            catch (Exception)
            {
                //Retrieve the exception
                throw;
            }
        }
    }
}
