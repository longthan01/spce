using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SomeApp.Abstractions.Services;
using SomeApp.Models;

namespace SomeApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountService _accountService;

        public AccountsController(ILogger<AccountsController> logger, IAccountService accountService)
        {
	        _logger = logger;
	        _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAccount([FromBody, Required] AccountRegistrationRequest request)
        {
	        var accountId = await this._accountService.RegisterAsync(request);
	        return Created("acount-some-where", accountId);
        }
    }
}
