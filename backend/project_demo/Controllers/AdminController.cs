using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_demo.Data;
using project_demo.Model;
using project_demo.NewFolder2;

namespace project_demo.Controllers
{
     //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ItokenRepository tokenRepository;
        private readonly AppDbContext _Context;

        public AdminController(AppDbContext context, UserManager<IdentityUser> userManager, ItokenRepository tokenRepository)
        {
            _Context = context;
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] string email, [FromQuery] string password)
        {
            var admin = _Context.Admins.FirstOrDefault(a => a.Email == email && a.Password == password);
            if (admin == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var identityUser = await userManager.FindByEmailAsync(email);
            if (identityUser == null)
            {
                identityUser = new IdentityUser
                {
                    UserName = admin.Username,
                    Email = email
                };
                var result = await userManager.CreateAsync(identityUser, password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return Unauthorized($"Failed to register admin in Identity system: {errors}");
                }
            }
            await userManager.AddToRoleAsync(identityUser, "Admin");

            var roles = await userManager.GetRolesAsync(identityUser);
            var token = tokenRepository.CreateJwtToken(identityUser, string.Join(",", roles));
         

            return Ok(new { message = "Admin logged in successfully", Token = token });

        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("Pending-request")]
        public IActionResult GetPendingRequest()
        {
            var PendingRequests=_Context.Registrationrequests.Where(r=>r.IsApproved==false).ToList();
            List<dynamic> var = new List<dynamic>();
            foreach(var x in PendingRequests)
            {
                var.Add(new { id = x.Id, name = x.Username, Isapproved = x.IsApproved });
            }
            
            return Ok(var);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("approve/{id}")]
        public async Task<IActionResult> ApproveRequest(int id, [FromQuery] bool approve)
        {
            var request = _Context.Registrationrequests.FirstOrDefault(r => r.Id == id);
            if (request == null)
            {
                return NotFound("Registration request not found");
            }

            request.IsApproved = approve;

            if (approve)
            {
                var identityUser = new IdentityUser
                {
                    UserName = request.Username, // Ensure this is a valid username
                    Email = request.Email
                };
                var identityResult = await userManager.CreateAsync(identityUser, request.Password);
                if (identityResult.Succeeded)
                {
                    if (!string.IsNullOrEmpty(request.Role))
                    {
                        identityResult = await userManager.AddToRoleAsync(identityUser, request.Role);
                    }

                    var user = new User
                    {
                        Username = request.Username,
                        Password = request.Password,
                        IsApproved = true,
                        Email = request.Email
                    };
                    _Context.Users.Add(user);
                    await _Context.SaveChangesAsync();

                    if (identityResult.Succeeded)
                    {
                        return Ok(new { success = true, message = "User registration successful" });
                    }
                }
            }

            return BadRequest("Something went wrong");
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("approved-users")]
        public IActionResult GetApprovedUsers()
        {
            var approvedUsers = _Context.Users
                .Where(u => u.IsApproved)
                .Select(u => new
                {
                    u.USerId,
                    u.Username,
                    u.Email,
                    // Do not include the password in the response for security reasons
                })
                .ToList();

            return Ok(approvedUsers);
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> deleterequest(int id)
        {
            var user = _Context.Users.FirstOrDefault(u => u.USerId == id);
            if(user==null)
            {
                return NotFound("User not found");
            }
            _Context.Users.Remove(user);
            await _Context.SaveChangesAsync();
            return Ok(new { success = true, message = $"User {user.Username} deleted successfully" });
        }

    }
}
