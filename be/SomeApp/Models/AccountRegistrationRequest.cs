using System.ComponentModel.DataAnnotations;

namespace SomeApp.Models
{
	public class AccountRegistrationRequest
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
		public string Fullname { get; set; }
        public string Address { get; set; }
	}
}