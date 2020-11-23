using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_System.Data
{
    public class Employee
    {
       // [Key]
        public int Id { set; get; }
        [Required]
        public string fullname { set; get; }
        public string Email { set; get; }
        public DateTime Birthdate { set; get; }
       // [ForeignKey("GenderId")]
        public int GenderId { set; get; }
        public Gender Gender { get; set; }
        public List<VacationAllocation> Allocations { set; get; }
        public List<VacationRequest> Requests { set; get; }
    }
}
