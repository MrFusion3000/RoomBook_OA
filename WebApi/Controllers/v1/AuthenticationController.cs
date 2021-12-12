using Application.Interfaces;
using Application.Shared.DTO;
using Domain.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.ActionFilters;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AuthenticationController : BaseApiController
    {
        //private readonly ILoggerManager _logger;
        //AutoMapper stuff
        //private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;

        public AuthenticationController(/*ILoggerManager logger, IMapper mapper,*/ UserManager<User> userManager, IAuthenticationManager authManager)
        {
            //_logger = logger;
            //_mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = userForRegistration.Adapt<User>();
            var result = await _userManager.CreateAsync(user, userForRegistration.Password); if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            await _userManager.AddToRolesAsync(user, userForRegistration.Roles); return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                //_logger.LogWarn($"{nameof(Authenticate)}: Authentication failed. Wrong 
                //user name or password.");
            return Unauthorized();
            }
            return Ok(new { Token = await _authManager.CreateToken() });
        }
    }
}
