using Leave_System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_System.Models
{
    public class VacationRequestVM
    {
        public int Id { set; get; }
        // [ForeignKey("EmployeeId")]
        public int EmployeeId { set; get; }
        //[ForeignKey("VacationTypeId")]
        public string EmployeeName { set; get; }
        public int VacationTypeId { set; get; }
        public string VacationTypeName { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime EndDate { set; get; }
        public DateTime DateRequested { set; get; }
        public bool Status { set; get; }
        public bool? Cancelled { set; get; }
        public IEnumerable<SelectListItem> vacationtypes { set; get; }
    }




}