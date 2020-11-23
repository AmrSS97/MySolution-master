using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_System.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public IEnumerable<SelectListItem> GenderItems { get; set; }
    }
}
