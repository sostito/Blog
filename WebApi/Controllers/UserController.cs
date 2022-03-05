using Application.Services.Interface;
using Data.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Models.Request;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        ///<summary>
        /// Permite realizar login en la aplicación
        /// </summary>
        /// <response code="401">Error de autenticación</response>
        /// <response code="200">Login exitoso</response>
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] Login login)
        {
            try
            {
                var user = await userService.Login(login);
                if (user != null)
                    return Ok(new { token = tokenService.GetToken(user) });
                return Unauthorized("Usuario o contraseña inválidos");
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }

        ///<summary>
        /// Permite crear un nuevo usuario
        /// </summary>
        /// <response code="200">Usuario creado correctamente</response>
        /// <response code="400">Error al crear nuevo usuario</response>
        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var user = createUserRequest.Adapt<User>();
            var response = await userService.CreateUser(user);
            return StatusCode(response ? 200 : 400);
        }

    }
}
