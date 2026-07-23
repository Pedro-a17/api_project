using PokeShop.Application.DTOs.Login;

namespace PokeShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        readonly ILoginService _loginService;

        public LoginController(ILoginService loginService) => _loginService = loginService;

        [HttpPost("login")]
        public async Task<ActionResult<LoginResultDto>> Login([FromBody] LoginDto dto)
        {
            try
            {
                var r = await _loginService.LoginAsync(dto.UserName, dto.Password);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddHours(2)
                };

                Response.Cookies.Append("jwt", r.Jwt, cookieOptions);

                return Ok(new {
                    message = r.Message,
                    userName = r.UserName,
                    coins = r.Coins
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }  
    }
}