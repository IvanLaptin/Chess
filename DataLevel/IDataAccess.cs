using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLevel.Model;

namespace DataLevel
{
	public interface IDataAccess
	{
		AccountProxy SignIn(string login, string password);
		bool SignUp(string login, string password, string email, string fullname);


	}
}
