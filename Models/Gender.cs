using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_System.Data
{
    public class Gender
    {
        //[Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public List<Employee> Employees { get; set; }
    }
}
