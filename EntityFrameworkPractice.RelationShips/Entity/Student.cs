using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.RelationShips.Entity;
public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Classroom { get; set; }
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
}
