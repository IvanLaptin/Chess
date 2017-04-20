
using DataLevel.Interface;
using DataLevel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLevel.Logic
{
	class Authorization : IAuthorization
	{

		public AccountProxy LogIn(string login, string password)
		{
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = "chesss.database.windows.net";
			builder.UserID = "laptin";
			builder.Password = "Qwerty777";
			builder.InitialCatalog = "chessSql";
			using (var connection = new SqlConnection(builder.ConnectionString))
			{
				connection.Open();
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO Account([Login], [Password])");
				String sql = sb.ToString();

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							return null;
						}
					}
				}
			}
			return null;
		}

		public bool SignUp(string login, string password, string email, string fullname)
		{
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = "chesss.database.windows.net";
			builder.UserID = "laptin";
			builder.Password = "Qwerty777";
			builder.InitialCatalog = "chessSql";
			using (var connection = new SqlConnection(builder.ConnectionString))
			{
				connection.Open();
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO [Account] ([Login], [Password], [Email], [FullName]) ");
				sb.Append("VALUES (@Login, @Password, @Email, @FullName);");
				String sql = sb.ToString();
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@Login", login);
					command.Parameters.AddWithValue("@Password", password);
					command.Parameters.AddWithValue("@Email", email);
					command.Parameters.AddWithValue("@FullName", fullname);
					int rowsAffected = command.ExecuteNonQuery();
					return rowsAffected != 0;
				}
			}
		}
	}
}
