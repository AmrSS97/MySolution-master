using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_System.Models
{
    public class VacationAllocationVM
    {
        public int Id { set; get; }
        public string EmployeeName { set; get; }
        // [ForeignKey("EmployeeId")]
        public int EmployeeId { set; get; }
        // [ForeignKey("VacationTypeId")]
        public string VacationTypeName { set; get; }
        public int VacationTypeId { set; get; }
        public int Used { set; get; }
    }
}
