using System;





namespace BBC
{
    public class User
    {
        public string username { get; set; }

        public int id { get; set; }

        public string password { get; set; }

        public int roleId { get; set; }

        public User(string username, int id, string password, int roleid)
        {
            username = username;
            id = id;
            password = password;
            roleId = roleid;
        }



    }
}