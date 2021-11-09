using System.Threading.Tasks;
using SomeApp.Models;

namespace SomeApp.Abstractions.Services
{
	public interface IAccountService
	{
		Task<int> RegisterAsync(AccountRegistrationRequest request);
		Task VerifyAsync(AccountVerificationRequest request);
	}
}
