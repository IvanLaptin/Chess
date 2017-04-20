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

		public DataAccess()
		{
			authorization = new Authorization();
		}

		public AccountProxy SignIn(string login, string password)
		{
			var acc = authorization.LogIn(login, password);
			return new AccountProxy() { Id = acc.Id, Email = acc.Email, FullName = acc.FullName, Password = password };
		}

		public bool SignUp(string login, string password, string email, string fullname)
		{
			return authorization.SignUp(login, password, email, fullname);
		}
	}
}
