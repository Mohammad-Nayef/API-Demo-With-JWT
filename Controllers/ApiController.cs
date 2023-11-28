using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalApiWithJwt.Models;
using MinimalApiWithJwt.Services;

namespace JWT.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IUserService _userService;

        public ApiController(
            IMapper mapper,
            ITokenGenerator tokenGenerator,
            IUserService userService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _tokenGenerator =
                tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("custom-auth")]
        public IActionResult GetCustomAuth()
        {
            if (!ValidateAuthorization())
                return Unauthorized();

            return Ok("You are authorized! Enjoy your cup of tea.");
        }

        private bool ValidateAuthorization()
        {
            var authorizationToken = Request.Headers["Authorization"];
            return _tokenGenerator.ValidateToken(authorizationToken);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("You are authorized! Enjoy your cup of tea.");
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO userRegister)
        {
            var user = _mapper.Map<UserDTO>(userRegister);
            _userService.Add(user);

            var userWithoutPassword = _mapper.Map<UserWithoutPasswordDTO>(user);
            var token = _tokenGenerator.GenerateToken(userWithoutPassword);

            return Ok(new { BearerToken = token });
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLogin)
        {
            var user = AuthenticateUser(userLogin);

            if (user == null)
                return Unauthorized();

            var userWithoutPassword = _mapper.Map<UserWithoutPasswordDTO>(user);
            var token = _tokenGenerator.GenerateToken(userWithoutPassword);

            return Ok(new { BearerToken = token });
        }

        /// <summary>
        /// To determine where the user credentials are authenticated or not.
        /// </summary>
        /// <returns>The authenticated user or null if not authenticated</returns>
        private UserDTO AuthenticateUser(UserLoginDTO userLogin)
        {
            var user = _userService.GetAll().FirstOrDefault(user =>
            {
                if (user.Username == userLogin.Username &&
                    user.Password == userLogin.Password)
                    return true;

                return false;
            });

            return user;
        }
    }
}
