using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLevel
{
	public static class DbSetings
	{
		const string LOGIN = "laptin";
		const string PASSWORD = "Qwerty777";
		const string HOST = "chesss.database.windows.net";
		const string DBNAME = "chessSql";

		public static string GetConnectionString()
		{
			try
			{
				SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
				builder.DataSource = HOST;
				builder.UserID = LOGIN;
				builder.Password = PASSWORD;
				builder.InitialCatalog = DBNAME;
				return builder.ConnectionString;
			}
			catch (Exception err)
			{
				throw err;
			}

		}
	}
}
