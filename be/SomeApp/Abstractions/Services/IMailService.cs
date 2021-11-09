using System.Threading.Tasks;
using SomeApp.Models;

namespace SomeApp.Abstractions.Services
{
	public interface IMailService
	{
		Task Send(MailRequest request);
	}
}