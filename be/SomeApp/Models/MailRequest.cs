namespace SomeApp.Models
{
	public class MailRequest
	{
		public string To { get; set; }
		public string Username { get; set; }
		public string VerificationToken { get; set; }
		public string Content { get; set; }
		public string Subject { get; set; }
	}
}