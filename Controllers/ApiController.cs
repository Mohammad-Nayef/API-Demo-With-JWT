using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinimalApiWithJwt.Extensions;
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

        /// <summary>
        /// Get a message using custom token authorization
        /// </summary>
        /// <response code="200">String message</response>
        [HttpGet("custom-auth")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>
        /// Get a message using the default token authorization
        /// </summary>
        /// <response code="200">String message</response>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok("You are authorized! Enjoy your cup of tea.");
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="userRegister"></param>
        /// <response code="200">Token for authorization</response>        
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Register(UserRegisterDTO userRegister)
        {
            var user = _mapper.Map<UserDTO>(userRegister);
            _userService.Add(user);

            var userWithoutPassword = _mapper.Map<UserWithoutPasswordDTO>(user);
            var token = _tokenGenerator.GenerateToken(userWithoutPassword);

            return Ok(new { Token = token });
        }

        /// <summary>
        /// Login to an existing user account
        /// </summary>
        /// <param name="userLogin"></param>
        /// <response code="200">Token for authorization</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login(UserLoginDTO userLogin)
        {
            var user = AuthenticateUser(userLogin);

            if (user == null)
                return Unauthorized();

            var userWithoutPassword = _mapper.Map<UserWithoutPasswordDTO>(user);
            var token = _tokenGenerator.GenerateToken(userWithoutPassword);

            return Ok(new { Token = token });
        }

        /// <summary>
        /// To determine where the user credentials are authenticated or not.
        /// </summary>
        /// <returns>The authenticated user or null if not authenticated</returns>
        private UserDTO AuthenticateUser(UserLoginDTO userLogin)
        {
            return _userService.GetAll().FindMatchingUser(userLogin);
        }
    }
}
