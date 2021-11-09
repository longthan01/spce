using System;

namespace SomeApp.Implementations.DbContext
{
	public class Account
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string VerificationToken { get; set; }
		public DateTime VerificationTokenExpirationTime { get; set; }
		public bool IsVerified { get; set; }
	}
}