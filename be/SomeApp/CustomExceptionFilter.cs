using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace SomeApp
{
	public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			var exception = context.Exception;
			var error = new { message = $"{exception.Message}" };
			context.Result = new ContentResult
			{
				Content = JsonConvert.SerializeObject(error),
				ContentType = "application/json",
				StatusCode = (int?)HttpStatusCode.InternalServerError
			};
		}
	}
}
