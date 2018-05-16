using System;





namespace BBC
{
    public class User
    {
        public string Username { get; set; }

        public int Id { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public User(string username, int id, string password, int roleid)
        {
            Username = username;
            Id = id;
            Password = password;
            RoleId = roleid;
        }



    }
}