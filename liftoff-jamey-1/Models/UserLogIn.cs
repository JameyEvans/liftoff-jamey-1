using System;
namespace liftoff_jamey_1.Models
{
	public class UserLogIn
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public int Password { get; set; }

		public UserLogIn()
		{
		}
	}
}

