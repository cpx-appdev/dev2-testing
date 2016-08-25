namespace CoolUserWorld.Api.Controllers
{
    using System;
    using System.Net;
    using System.Web.Http;

    public class UserApiController : ApiController
    {
        private readonly ICredentialService _credentialService;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;

        public UserApiController(ICredentialService credentialService, IUserRepository userRepository, ILogger logger)
        {
            _credentialService = credentialService;
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost]
        public ApiResult CreateUser(User user)
        {
            try
            {

                if (_credentialService.UserExists(user))
                    throw new HttpResponseException(HttpStatusCode.Conflict);

                if (!_credentialService.CheckUserCredentials(user))
                    throw new HttpResponseException(HttpStatusCode.NotFound);

                _userRepository.CreateUser(user);

                return new ApiResult { Success = true };
            }

            catch (Exception exc)
            {
                _logger.Error("irgendwas halt");
                throw exc;
            }
        }
    }

    public class ApiResult
    {
        public bool Success { get; set; }
    }
}

