using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SomeApp.Abstractions.Services;
using SomeApp.Models;

namespace SomeApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountVerificationController : ControllerBase
	{
		private readonly IAccountService _accountService;

		public AccountVerificationController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpPost]
		public async Task<IActionResult> Verify([FromBody, Required] AccountVerificationRequest request)
		{
			await this._accountService.VerifyAsync(request);
			return Ok();
		}
	}
}
