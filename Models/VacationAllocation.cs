using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_System.Data
{
    public class VacationAllocation
    {
       // [Key]
        public int Id { set; get; }
        public Employee Employee { set; get; }
       // [ForeignKey("EmployeeId")]
        public int EmployeeId { set; get; }
       // [ForeignKey("VacationTypeId")]
        public VacationType VacationType { set; get; }
        public int VacationTypeId { set; get; }
        public int Used { set; get; }
    }
}
