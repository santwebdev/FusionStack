using FusionStackBackEnd.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FusionStackBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserserveController: ControllerBase
    {
        private LoginRepositoryImpl repo;

        public UserserveController(LoginRepositoryImpl repo)
        {
            this.repo = repo;
        }

        //Authorise will check token and check role and then will give access 
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult GetUserDetails(string code)
        {
           //Email from Token
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            
            if (userEmail == null)
            {
                return BadRequest();
            }
            //LoginRepositoryImpl call for geting user  
            var user = repo.getUserByEmail(userEmail);
            return Ok(user);
        }

    }
}
