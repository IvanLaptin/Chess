using DataLevel.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLevel.Model
{
	public class MatcheProxy
	{
		public int Id { get; set; }
		public AccountProxy Account1 { get; set; }
		public AccountProxy Account2 { get; set; }
		public AccountProxy AccountWin { get; set; }

		public MatcheProxy()
		{
			Account1 = new AccountProxy();
			Account2 = new AccountProxy();
			AccountWin = new AccountProxy();
		}

		public MatcheProxy(AccountProxy account1, AccountProxy account2, AccountProxy accountWin)
		{
			this.Account1 = account1;
			this.Account2 = account2;
			this.AccountWin = accountWin;
		}
	}
}
