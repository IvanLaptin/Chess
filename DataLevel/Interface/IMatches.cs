using DataLevel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLevel.Interface
{
	public interface IMatches
	{
		void CreateMatche(AccountProxy account1, AccountProxy account2, AccountProxy accountWin);
		void CreateMatche(MatcheProxy matche);
		void DeleteMatcheById(int id);
		MatcheProxy GetMatcheById(int id);
		List<MatcheProxy> GetMatchesAvalibelAccountId(int accountId);
		List<MatcheProxy> GetMatchesWinAccountId(int accountId);

	}
}
