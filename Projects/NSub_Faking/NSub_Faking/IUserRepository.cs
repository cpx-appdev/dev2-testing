namespace CoolUserWorld
{
    public interface IUserRepository
    {
        User GetById(int userId);

        void CreateUser(User user);
    }
}