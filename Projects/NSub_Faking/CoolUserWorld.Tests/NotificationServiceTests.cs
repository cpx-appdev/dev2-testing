namespace CoolUserWorld.Tests
{
    using NSubstitute;
    using Xunit;

    public class NotificationServiceTests
    {
        private IUserRepository _userRepository;
        private INotifier _notifier;
        private ILogger _logger;
        private NotificationService _sut;

        public NotificationServiceTests()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _notifier = Substitute.For<INotifier>();
            _logger = Substitute.For<ILogger>();

            _sut = new NotificationService(_userRepository, _notifier, _logger);
        }

        [Fact(DisplayName = "NotifyUser calls logger when an exception is thrown")]
        public void Call_Logger_When_An_Exception_Is_Thrown()
        {
            _userRepository.GetById(Arg.Is<int>(i => i < 0)).Returns(user => { throw new InvalidUserIdException(); });

            _sut.NotifyUser(-1);
            _logger.Received().Error("Given user ID is invalid");
        }

        [Fact(DisplayName = "NotifyUser calls logger with Info when an user is notified")]
        public void Call_Logger_Info_When_An_User_Is_Notified()
        {
            _userRepository.GetById(Arg.Any<int>()).Returns(new User(){HasActivatedNotification = true});

            _notifier.LogInfoNotifyUser = true;

            _sut.NotifyUser(1);

            _logger.Received(1).Info("User was notified");
        }

        [Fact(DisplayName = "NotifyUser calls the repository")]
        public void Call_Repository()
        {
            _userRepository.GetById(Arg.Any<int>()).Returns(new User());

            _sut.NotifyUser(1);

            _userRepository.Received().GetById(Arg.Any<int>());
        }

        [Fact(DisplayName = "NotifyUser calls notifier if user has activated the notifications")]
        public void Call_Notifier_When_User_Has_Activated_Notification()
        {
            _userRepository.GetById(1).Returns(new User { HasActivatedNotification = true });

            _sut.NotifyUser(1);

            _notifier.Received().Notify(Arg.Any<User>());
        }

        [Fact(DisplayName = "NotifyUser does not call notifier if user has not activated the notifications")]
        public void Does_Not_Call_Notifier_When_User_Has_Not_Activated_Notification()
        {
            _userRepository.GetById(Arg.Any<int>()).ReturnsForAnyArgs(new User { HasActivatedNotification = false });

            _sut.NotifyUser(1);

            _notifier.DidNotReceive().Notify(Arg.Any<User>());
        }
    }
}
