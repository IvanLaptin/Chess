using DataLevel.Interface;
using DataLevel.Logic;
using DataLevel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLevel
{
	public class DataAccess : IDataAccess
	{

		IAuthorization authorization { get; set; }
		IMatches matches { get; set; }

		public DataAccess()
		{
			authorization = new Authorization();
			matches = new Matches();
		}

		public AccountProxy LogIn(string login, string password)
		{
			return authorization.LogIn(login, password);
		}

		public bool SignUp(string login, string password, string email, string fullname)
		{
			return authorization.SignUp(login, password, email, fullname);
		}

        public bool ChangePassword(string login, string password)
        {
            return authorization.ChangePassword(login, password);
        }


		public bool IsBusy(string login, string email)
		{
			return authorization.IsBusy(login, email);
		}

		public void CreateMatche(AccountProxy account1, AccountProxy account2, AccountProxy accountWin)
		{
			matches.CreateMatche(account1, account2, accountWin);
		}

		public void CreateMatche(MatcheProxy matche)
		{
			matches.CreateMatche(matche);
		}

		public void DeleteMatcheById(int id)
		{
			//TODO:
			matches.DeleteMatcheById(id);
		}

		public MatcheProxy GetMatcheById(int id)
		{
			return matches.GetMatcheById(id);
		}

		public List<MatcheProxy> GetMatchesAvalibelAccountId(int accountId)
		{
			//TODO:
			return matches.GetMatchesAvalibelAccountId(accountId);
		}

		public List<MatcheProxy> GetMatchesWinAccountId(int accountId)
		{
			//TODO:
			return matches.GetMatchesWinAccountId(accountId);
		}
	}
}
