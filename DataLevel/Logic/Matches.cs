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
			CreateMatche(account1.Id, account2.Id, accountWin.Id);
		}

		public void CreateMatche(Model.MatcheProxy matche)
		{
			CreateMatche(matche.Account1, matche.Account2, matche.AccountWin);
		}

		public void CreateMatche(int accountId1, int accountId2, int accountWinId)
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
					command.Parameters.AddWithValue("@Account1Id", accountId1);
					command.Parameters.AddWithValue("@Account2Id", accountId2);
					command.Parameters.AddWithValue("@AccountWin", accountWinId);
					int rowsAffected = command.ExecuteNonQuery();
					//return rowsAffected != 0;
				}
			}
		}

		public void DeleteMatcheById(int id)
		{
			using (var connection = new SqlConnection(DbSetings.GetConnectionString()))
			{
				connection.Open();
				StringBuilder sb = new StringBuilder();
				sb.Append(string.Format("delete from [Matche] where [Id] = {0}", id));
				String sql = sb.ToString();
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					int rowsDeletedCount = command.ExecuteNonQuery();
					//return rowsAffected != 0;
				}
			}
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
							m.Id = reader.GetInt32(0);
							m.Account1 = GetAccountById(reader.GetInt32(1));
							m.Account2 = GetAccountById(reader.GetInt32(2));
							m.AccountWin = GetAccountById(reader.GetInt32(3));

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
			var listId = new List<int>();
			var matcheList = new List<MatcheProxy>();
			using (var connection = new SqlConnection(DbSetings.GetConnectionString()))
			{
				connection.Open();
				StringBuilder sb = new StringBuilder();
				sb.Append(string.Format("SELECT [Id]" +
				"FROM [chessSql].[dbo].[Matche] where [Account1Id] = {0} or [Account2Id] = {0};", accountId));
				String sql = sb.ToString();

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							MatcheProxy m = new MatcheProxy();
							listId.Add(reader.GetInt32(0));
						}
					}
				}
			}

			foreach (var item in listId)
			{
				matcheList.Add(GetMatcheById(item));
			}
			return matcheList;
		}

		public List<MatcheProxy> GetMatchesWinAccountId(int accountId)
		{
			return GetMatchesAvalibelAccountId(accountId).Where(m => m.AccountWin.Id == accountId).ToList();
		}
	}
}
