namespace ForumSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using Data;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var context = new ForumContext();

            var users = context.Users.ToList();

            foreach (User user in users)
            {
                Console.WriteLine(user.UserName);

                foreach (var friend in user.Friends)
                {
                    Console.WriteLine("---" + friend.UserName);
                }
            }
        }
    }
}
