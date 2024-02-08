using FusionStackBackEnd.Models;
using FusionStackBackEnd.Repository;
using FusionStackBackEnd.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FusionStackBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
       
        private readonly  LoginService service;
        private readonly LoginRepositoryImpl repo;
        public LoginController(LoginService service, LoginRepositoryImpl repo)
        {
           
            this.service = service;
            this.repo = repo;
        }

        //Login Request Handler
        [HttpPost]
        public IActionResult Dologin([FromBody] LoginDto dto)
        {
            if (dto==null||string.IsNullOrEmpty(dto.Email)|| string.IsNullOrEmpty(dto.Password))
            {
                return StatusCode(400, "Bad Tequest");
            }
            //Token crated or befor create it validated in LoginService
            var token = service.isRightCredentials(dto.Email, dto.Password);
            if (token== null)
            {
                return StatusCode(400, "Bad Credential");
            };
           //afrter Authentication Token send to client
            return Ok(new { token });
            
        }
       
        


    }

    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
}
