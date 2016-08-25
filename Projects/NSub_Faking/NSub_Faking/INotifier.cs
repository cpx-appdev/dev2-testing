namespace CoolUserWorld
{
    public interface INotifier
    {
        void Notify(User user);
        bool LogInfoNotifyUser { get; set; }
    }
}