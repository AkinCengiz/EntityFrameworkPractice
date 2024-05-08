using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPractice.KeylessEntityType.Entity;
public class ProductFull
{
    public int Product_Id { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Color { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

}
