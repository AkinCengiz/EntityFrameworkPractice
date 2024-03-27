using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.OwnedEntityType.Entity;
public class Employee
{
    public int Id { get; set; }
    public Person Person { get; set; }
    public decimal Salary { get; set; }
    public DateTime StartDate { get; set; }
}
