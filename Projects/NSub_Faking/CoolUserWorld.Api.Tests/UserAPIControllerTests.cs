﻿namespace CoolUserWorld.Api.Tests
{
    using System;
    using System.Net;
    using System.Web.Http;
    using Controllers;
    using NSubstitute;
    using Shouldly;
    using Xunit;

    public class UserApiControllerTests
    {
        private readonly ICredentialService _credentialService;
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        private readonly UserApiController _sut;
        private INotifier _notifier;

        public UserApiControllerTests()
        {
            _credentialService = Substitute.For<ICredentialService>();
            _userRepository = Substitute.For<IUserRepository>();
            _logger = Substitute.For<ILogger>();
            _notifier = Substitute.For<INotifier>();

            _sut = new UserApiController(_credentialService, _userRepository, _logger, _notifier);
        }

        private void GivenAllValidationCheckAreSuccessful()
        {
            _credentialService.UserExists(Arg.Any<User>()).ReturnsForAnyArgs(false);
            _credentialService.CheckUserCredentials(Arg.Any<User>()).ReturnsForAnyArgs(true);
        }

        [Fact]
        public void CreateUser_Call_Create_User_If_Validation_Checks_Where_Successful()
        {
            var user = new User();

            GivenAllValidationCheckAreSuccessful();

            var result = _sut.CreateUser(user);

            Received.InOrder(() =>
            {
                _credentialService.UserExists(Arg.Any<User>());
                _credentialService.CheckUserCredentials(Arg.Any<User>());
                _userRepository.CreateUser(Arg.Any<User>());
            });

            result.ShouldBeOfType<ApiResult>();
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public void CreateUser_Calls_CredentialService_And_Return_Status_Not_Found_if_User_Is_Invalid()
        {
            var user = new User();
            _credentialService.CheckUserCredentials(Arg.Any<User>()).ReturnsForAnyArgs(false);

            Action act = () => _sut.CreateUser(user);

            var result = act.ShouldThrow<HttpResponseException>();
            result.Response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact]
        public void CreateUser_Calls_CredentialService_And_Return_Status_Conflict_if_Account_Exists()
        {
            _credentialService.UserExists(Arg.Any<User>()).ReturnsForAnyArgs(true);
            Action act = () => _sut.CreateUser(new User());
            var result = act.ShouldThrow<HttpResponseException>();
            result.Response.StatusCode.ShouldBe(HttpStatusCode.Conflict);
        }

        [Fact]
        public void CreateUser_Dont_Call_Create_User_If_Validation_Checks_Failed()
        {
            _credentialService.UserExists(Arg.Any<User>()).ReturnsForAnyArgs(true);
            _credentialService.CheckUserCredentials(Arg.Any<User>()).ReturnsForAnyArgs(false);
            Should.Throw<HttpResponseException>(() => _sut.CreateUser(new User()));
            _userRepository.DidNotReceiveWithAnyArgs().CreateUser(null);
        }

        [Fact]
        public void CreateUser_Should_NotifyUser_With_ActivatedNotification_After_Create()
        {
            var user = new User { HasActivatedNotification = true };
            GivenAllValidationCheckAreSuccessful();
            _sut.CreateUser(user);
            _notifier.Received().Notify(user);
        }
    }
}
