using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniProject.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public List<ContactDetails> ContactDetails { get; set; }

        

        public Contact(int contactId, string firstName, string lastName, bool isActive)
        {
            ContactID = contactId;
            FirstName = firstName;
            LastName = lastName;
            IsActive = isActive;
            ContactDetails = new List<ContactDetails>();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} (Active: {IsActive})";
        }
    }



}
