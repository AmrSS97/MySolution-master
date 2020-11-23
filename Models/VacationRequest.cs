using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_System.Data
{
    public class VacationRequest
    {
       // [Key]
        public int Id { set; get; }
       // [ForeignKey("EmployeeId")]
        public int VacationAllocationId { set; get; }
        public int EmployeeId { set; get; }
        public Employee Employee { set; get; }
        //[ForeignKey("VacationTypeId")]
        public int VacationTypeId { set; get; }
        public VacationType VacationType { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime DateRequested { set; get; }
        public bool Status { set; get; }
        public bool? Cancelled { set; get; } 

    }
}
