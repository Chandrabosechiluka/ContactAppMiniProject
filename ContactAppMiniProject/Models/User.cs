using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniProject.Models
{

    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public List<Contact> Contacts { get; set; }

        

        public User(int userId, string firstName, string lastName, bool isAdmin, bool isActive)
        {
            UserID = userId;
            FirstName = firstName;
            LastName = lastName;
            IsAdmin = isAdmin;
            IsActive = isActive;
            Contacts = new List<Contact>();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} (Admin: {IsAdmin}, Active: {IsActive})";
        }
    }

}
