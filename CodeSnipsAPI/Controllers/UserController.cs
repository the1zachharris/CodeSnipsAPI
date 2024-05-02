
using System.Security.Claims;
using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using CodeSnipsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnipsAPI.Controllers;

[Route("[controller]s")]
[ApiController]
public class UserController : ControllerBase
{
	[HttpGet]
	[Authorize]
	public ActionResult<User> GetUser()
	{
		if (User.Identity == null)
		{
			return NotFound("User not logged in");
		}
		// return specific information about the logged-in user using .NET's built-in identity system and claims from Auth0 (Sub = unique identifier)
		return Ok(new
		{
			Name = User.Identity.Name,
			EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
			ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value,
			Sub = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value
		});
	}
}
