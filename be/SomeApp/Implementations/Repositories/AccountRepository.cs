using System;
using System.Linq;
using System.Threading.Tasks;
using SomeApp.Abstractions.Repositories;
using SomeApp.Implementations.DbContext;

namespace SomeApp.Implementations.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly InMemoryDbContext _dbContext;

		public AccountRepository(InMemoryDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> AddAsync(string userName, string password)
		{
			Random d = new Random();
			var account = new Account
			{
				Id = d.Next(), // temp fake
				Username = userName,
				Password = password,
				IsVerified = false,
				VerificationToken = Guid.NewGuid().ToString(),
				VerificationTokenExpirationTime = DateTime.Now.AddDays(3)
			};
			var newAccount = this._dbContext.Accounts.Add(account);
			await this._dbContext.SaveChangesAsync();
			return newAccount.Entity.Id;
		}

		public async Task<string> GetVerificationTokenAsync(int newAccountId)
		{
			var acc = this._dbContext.Accounts.FirstOrDefault(x => x.Id == newAccountId);
			return acc.VerificationToken;
		}

		public async Task<Account> GetByVerificationTokenAsync(string requestVerificationToken)
		{
			var account = this._dbContext.Accounts.FirstOrDefault(x => x.VerificationToken == requestVerificationToken);
			return account;
		}

		public async Task<Account> GetByUsername(string username)
		{
			var account = this._dbContext.Accounts.FirstOrDefault(x => x.Username == username);
			return account;
		}
	}
}