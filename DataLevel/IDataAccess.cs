using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLevel.Model;
using DataLevel.Interface;

namespace DataLevel
{
	public interface IDataAccess : IAuthorization, IMatches
	{
		//AccountProxy LogIn(string login, string password);
		//bool SignUp(string login, string password, string email, string fullname);
		//bool ChangePassword(string login, string password);

	}
}