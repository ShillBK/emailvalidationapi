using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace EmailValidationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost("validate")]
        public IActionResult Validate([FromBody] EmailRequest request)
        {
            bool isValid = Regex.IsMatch(
                request.Email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            );

            var domain = request.Email.Split('@')[1];

            return Ok(new
            {
                email = request.Email,
                isValid = isValid,
                domain = domain
            });
        }
    }

    public class EmailRequest
    {
        public string Email { get; set; }
    }
}
