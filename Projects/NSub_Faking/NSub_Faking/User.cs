namespace CoolUserWorld
{
    using System;

    public class User
    {
        public bool HasActivatedNotification { get; set; }
    }

    public class InvalidUserIdException : Exception
    {
        public override string Message
        {
            get { return "Given user ID is invalid"; }
        }
    }
}
