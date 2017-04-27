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
	}
}
