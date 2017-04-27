
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using DataLevel.Database;

namespace DataLevel.Model
{
	public class AccountProxy //: Account
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		
	}
}