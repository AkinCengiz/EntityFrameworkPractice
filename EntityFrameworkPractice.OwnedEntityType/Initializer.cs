using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkPractice.OwnedEntityType;
public class Initializer
{
    public static IConfiguration Configuration;

    public static void Build()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true);
        Configuration = builder.Build();
    }
}
