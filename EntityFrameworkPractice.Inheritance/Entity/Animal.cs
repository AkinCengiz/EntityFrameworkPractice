using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.Inheritance.Entity;
public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Length { get; set; }
    public decimal Weight { get; set; }
    public int Age { get; set; }

}
