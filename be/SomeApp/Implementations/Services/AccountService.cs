using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SomeApp.Abstractions.Repositories;
using SomeApp.Abstractions.Services;
using SomeApp.Implementations.DbContext;
using SomeApp.Models;

namespace SomeApp.Implementations.Services
{
	public class AccountService : IAccountService
	{
		private readonly IAccountRepository _accountRepository;
		private readonly IMailService _mailService;
		private readonly IConfiguration _configuration;
		private readonly InMemoryDbContext _dbContext;

		public AccountService(IAccountRepository accountRepository, IMailService mailService, IConfiguration configuration)
		{
			_accountRepository = accountRepository;
			_mailService = mailService;
			_configuration = configuration;
		}
		public async Task<int> RegisterAsync(AccountRegistrationRequest request)
		{
			var existingAccount = await this._accountRepository.GetByUsername(request.Username);
			if (existingAccount != null) throw new Exception("Account already existed");
			var newAccountId = await this._accountRepository.AddAsync(request.Username, request.Password, request.Fullname, request.Address);
			if (newAccountId > 0)
			{
				var verificationToken = await this._accountRepository.GetVerificationTokenAsync(newAccountId);
				await this._mailService.Send(new MailRequest
				{
					To = request.Username,
					Username = request.Username,
					Subject = "SomeApp account verification",
					VerificationToken = verificationToken,
					Content = $"<div>Click here to verify <a href='{GetVerificationUrl(verificationToken)}'>{GetVerificationUrl(verificationToken)}</a></div>"
				});
			}

			return newAccountId;
		}

		public async Task VerifyAsync(AccountVerificationRequest request)
		{
			var account = await this._accountRepository.GetByVerificationTokenAsync(request.VerificationToken);
			if (account == null) throw new Exception("Account not found");
			if (account.IsVerified) return;
			if (account.VerificationTokenExpirationTime > DateTime.Now)
			{
				account.IsVerified = true;
			}
			else
			{
				throw new Exception("Verification token expired");
			}
		}

		private string GetVerificationUrl(string token)
		{
			return $"{_configuration["AccountVerificationUrl"]}/{token}";
		}
	}
}