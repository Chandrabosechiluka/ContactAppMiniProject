using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniProject.Models
{ 
    public class ContactDetails
    {
        public int ContactDetailsID { get; set; }
        public string Type { get; set; }
        public string Detail { get; set; }
        public bool IsActive { get; set; }

        public ContactDetails() { }

        public ContactDetails(int contactDetailsId, string type, string detail, bool isActive = true)
        {
            ContactDetailsID = contactDetailsId;
            Type = type;
            Detail = detail;
            IsActive = isActive;
        }

        public override string ToString()
        {
            return $"{ContactDetailsID}: {Type} - {Detail}, Active: {IsActive}";
        }
    }
    

}
