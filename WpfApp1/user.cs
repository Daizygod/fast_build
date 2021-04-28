using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    //  class user
    class user
    {
        //public int Id { get; set; }
        //private int id;
        //public int Id { get; set; }
        //public int Id
        //{ get; set; }

        public int id { get; set; }

        private string login, email, password, admin_status;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Admin_status
        {
            get { return admin_status; }
            set { admin_status = value; }
        }
        public user() { }
        public user(string login, string email, string password, string admin_status) {
            this.login = login;
            this.email = email;
            this.password = password;
            this.admin_status = admin_status;
        }
        
    }
}
