using System.Threading.Tasks;
using SomeApp.Implementations.DbContext;

namespace SomeApp.Abstractions.Repositories
{
	public interface IAccountRepository
	{
		Task<int> AddAsync(string userName, string password, string fullname, string address);
		Task<string> GetVerificationTokenAsync(int newAccountId);
		Task<Account> GetByVerificationTokenAsync(string requestVerificationToken);
		Task<Account> GetByUsername(string username);
	}
}