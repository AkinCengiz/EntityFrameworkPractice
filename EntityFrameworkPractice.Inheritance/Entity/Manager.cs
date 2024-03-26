using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.Inheritance.Entity;
public class Manager : Person
{
    public int Grade { get; set; }
}
