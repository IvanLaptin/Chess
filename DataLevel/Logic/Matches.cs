using DataLevel.Interface;
using DataLevel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLevel.Logic
{
	public class Matches : IMatches
	{
		public void CreateMatche(Model.AccountProxy account1, Model.AccountProxy account2, Model.AccountProxy accountWin)
		{
			using (var connection = new SqlConnection(DbSetings.GetConnectionString()))
			{
				connection.Open();
				StringBuilder sb = new StringBuilder();
				sb.Append("INSERT INTO [Matche] ([Account1Id], [Account2Id], [AccountWin]) ");
				sb.Append("VALUES (@Account1Id, @Account2Id, @AccountWin);");
				String sql = sb.ToString();
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@Account1Id", account1.Id);
					command.Parameters.AddWithValue("@Account2Id", account2.Id);
					command.Parameters.AddWithValue("@AccountWin", accountWin.Id);
					int rowsAffected = command.ExecuteNonQuery();
					//return rowsAffected != 0;
				}
			}
		}

		public void CreateMatche(Model.MatcheProxy matche)
		{
			CreateMatche(matche.Account1, matche.Account2, matche.AccountWin);
		}

		public void DeleteMatcheById(int id)
		{
			throw new NotImplementedException();
		}

		public MatcheProxy GetMatcheById(int id)
		{
			using (var connection = new SqlConnection(DbSetings.GetConnectionString()))
			{
				connection.Open();
				StringBuilder sb = new StringBuilder();
				sb.Append(string.Format("SELECT [Id], [Account1Id], [Account2Id], [AccountWin]" +
				"FROM [chessSql].[dbo].[Matche] where [Id] = {0};", id));
				String sql = sb.ToString();

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							MatcheProxy m = new MatcheProxy();
							m.Account1 = GetAccountById(reader.GetInt32(0));
							m.Account2 = GetAccountById(reader.GetInt32(1));
							m.AccountWin = GetAccountById(reader.GetInt32(2));

							return m;
						}
					}
				}
			}
			return null;
		}

		AccountProxy GetAccountById(int id)
		{
			using (var connection = new SqlConnection(DbSetings.GetConnectionString()))
			{
				connection.Open();
				StringBuilder sb = new StringBuilder();
				sb.Append(string.Format("SELECT [Id], [Login], [Password], [Email], [FullName]" +
				"FROM [chessSql].[dbo].[Account] where [Id] = {0};", id));
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

							return account;
						}
					}
				}
			}
			return null;
		}

		public List<MatcheProxy> GetMatchesAvalibelAccountId(int accountId)
		{
			throw new NotImplementedException();
		}

		public List<MatcheProxy> GetMatchesWinAccountId(int accountId)
		{
			throw new NotImplementedException();
		}
	}
}
