
using DataLevel.Interface;
using DataLevel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataLevel;

namespace DataLevel.Logic
{
	class Authorization : IAuthorization
	{


		public AccountProxy LogIn(string login, string password)
		{
			using (var connection = new SqlConnection(DbSetings.GetConnectionString()))
			{
				connection.Open();
				StringBuilder sb = new StringBuilder();
				sb.Append(string.Format("SELECT [Id], [Login], [Password], [Email], [FullName]" +
				"FROM [chessSql].[dbo].[Account] where [Login] = '{0}' and [Password] = '{1}';", login, password));
				String sql = sb.ToString();

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							AccountProxy account = new AccountProxy();
							account.Id = reader.GetInt32(0);
							account.Login = reader.GetString(1);
							account.Password = reader.GetString(2);
							account.Email = reader.GetString(3);
							account.FullName = reader.GetString(4);

							if (account.Login == login && account.Password == password) return account;
						}
					}
				}
			}
			return null;
		}

		public bool SignUp(string login, string password, string email, string fullname)
		{
			using (var connection = new SqlConnection(DbSetings.GetConnectionString()))
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

        public bool ChangePassword(string login, string password)
        {
            using (var connection = new SqlConnection(DbSetings.GetConnectionString()))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();

                sb.Append("UPDATE [Account] SET [Password] = @Password WHERE [Login] = @Login");
                String sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Login", login);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected != 0;
                }
            }
        }


		public bool IsBusy(string login, string email)
		{
			using (var connection = new SqlConnection(DbSetings.GetConnectionString()))
			{
				connection.Open();
				StringBuilder sb = new StringBuilder();
				sb.Append(string.Format("SELECT [Id], [Login], [Email]" +
				"FROM [chessSql].[dbo].[Account] where [Login] = '{0}' or [Email] = '{1}';", login, email));
				String sql = sb.ToString();

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							AccountProxy account = new AccountProxy();
							account.Id = reader.GetInt32(0);
							account.Login = reader.GetString(1);
							account.Email = reader.GetString(2);

							return (account.Login == login || account.Email == email);
							
						}
						return false;
					}
				}
			}
		}
	}
}