using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLevel.Model;

namespace DataLevel
{
	public interface IDataAccess
	{
		AccountProxy LogIn(string login, string password);
        bool SignUp(string login, string password, string email, string fullname);
        bool ChangePassword(string login, string password);

	}
}