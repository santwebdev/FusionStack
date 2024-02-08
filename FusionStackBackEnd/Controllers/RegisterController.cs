using FusionStackBackEnd.Models;
using FusionStackBackEnd.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FusionStackBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        //Constructor base Injection 
        private readonly SignupRepositoryImpl signupRepo;

        public RegisterController(SignupRepositoryImpl signupRepo)
        {
            this.signupRepo = signupRepo ?? throw new ArgumentNullException(nameof(signupRepo));
        }

        //Registration Handler
        [HttpPost]
        public IActionResult Register([FromBody] RegisterModelDto model)
            {

            try
            {
                if (model.Name == "" || model.Name==null )
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Name is null");
                }

                if (model.Email == "" || model.Email==null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Email is null");
                }
                if (model.Password == "" || model.Password==null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Password is null");
                }

                User newUser = new User();
                newUser.Name = model.Name;
                newUser.Email = model.Email;
                newUser.Password = model.Password;
                // Repository call
                signupRepo.AddUser(newUser);
    }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            //After success
                return Ok("Registration successful");
            }
     }

        public class RegisterModelDto
        {
           
            public string Email { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
        }
    }



