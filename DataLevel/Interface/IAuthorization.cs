using DataLevel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLevel.Interface
{
	interface IAuthorization
	{
		AccountProxy LogIn(string login, string password);

		bool SignUp(string login, string password, string email, string fullname);

	}
}
