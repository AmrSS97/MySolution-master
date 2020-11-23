using Leave_System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_System.Models
{
    public class VacationTypeVM
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Balance { set; get; }
        public List<VacationAllocation> VacationAllocations { set; get; }
    }
}
