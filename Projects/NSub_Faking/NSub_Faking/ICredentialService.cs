namespace CoolUserWorld
{
    public interface ICredentialService
    {
        bool CheckUserCredentials(User user);

        bool UserExists(User user);
    }
}
