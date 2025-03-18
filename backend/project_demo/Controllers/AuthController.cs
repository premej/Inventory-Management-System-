using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using project_demo.Data;
using project_demo.Model;
using project_demo.Model.DTO;
using project_demo.NewFolder2;


namespace project_demo.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ItokenRepository tokenrepository;
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context, UserManager<IdentityUser> userManager, ItokenRepository tokenrepository)
        {
            _context = context;
            this.userManager = userManager;
            this.tokenrepository = tokenrepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromQuery] string username, [FromQuery] string password, [FromQuery] string role, [FromQuery] string email)
        {
            //if (_context.Users.Any(u => u.Username == username))
            //{
            //    return BadRequest("Username already exists");
            //}

            if (_context.Users.Any(u => u.Email == email))
            {
                return BadRequest("Email already exists");
            }

            var request = new Registrationrequest
            {
                Username = username,
                Password = password,
                Role = role,
                IsApproved = false,
                Email = email // Add this line
            };

            _context.Registrationrequests.Add(request);
            await _context.SaveChangesAsync();
            return Ok(new { message= "Registration request submitted for admin approval"});
        }
            //[HttpGet("login")]

            //public async Task<IActionResult> login([FromQuery] string username, [FromQuery] string password)
            //{
            //    var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            //    if (user == null)
            //    {
            //        return Unauthorized(new { message = "Invalid username or password" });
            //    }
            //    return Ok(new { message = "login successful" });

            //    if (user != null)
            //    {
            //        var token = JwtTokenGenerator.GenerateToken(
            //            login.UserName,
            //            _configuration["Jwt:Key"],
            //            _configuration["Jwt:Issuer"],
            //            _configuration["Jwt:Audience"]
            //            );
            //        return Ok(new { Token = token });
            //    }
            //    return Unauthorized();
            //}

            [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] loginDTO logi)

        {
            //    public string UserName { get; set; }
            //public string Password { get; set; }

            var user = await userManager.FindByEmailAsync(logi.Email);
            if (user != null)
            {
                var res = await userManager.CheckPasswordAsync(user,logi. Password);
                if (res)
                {
                    //get role of user
                   // await userManager.AddToRoleAsync(identityUser, "Admin");
                    var roles = await userManager.GetRolesAsync(user);
                    string role = roles.FirstOrDefault();

                    //Create Token

                    var jwtToken = tokenrepository.CreateJwtToken(user, role);

                    return Ok(new { message = "User logged in successfully",Token=jwtToken });
                }
            }
            return BadRequest("invalid credentials");
        }

    }
}
