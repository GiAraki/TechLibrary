﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Api.UseCases.Login.DoLogin;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessageJson), StatusCodes.Status401Unauthorized)]
        public IActionResult DoLogin(RequestLoginJson request)
        {
            var useCase = new DoLoginUseCase();

            var response = useCase.Execute(request);

            return Ok(response);
        }
    }
}
