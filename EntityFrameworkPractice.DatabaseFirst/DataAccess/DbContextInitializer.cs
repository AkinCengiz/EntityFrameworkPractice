﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkPractice.DatabaseFirst.DataAccess;

public class DbContextInitializer
{
	public static IConfigurationRoot Configuration;
	public static DbContextOptionsBuilder<DbFirstContext> OptionsBuilder;

	public static void Build()
	{
		var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
		Configuration = builder.Build();

		//OptionsBuilder = new DbContextOptionsBuilder<DbFirstContext>();
		//OptionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlCon"));
	}
}
