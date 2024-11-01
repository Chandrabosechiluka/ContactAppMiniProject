using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using ContactAppMiniProject.Models;


namespace ContactAppMiniProject.Services
{
    public class ContactAppSerialization
    {
        private readonly string userFilePath;
        private readonly string contactFilePath;

        public ContactAppSerialization()
        {
            userFilePath = System.Configuration.ConfigurationManager.AppSettings["UserFilePath"];
            contactFilePath = System.Configuration.ConfigurationManager.AppSettings["ContactFilePath"];
        }

        public void SaveUsers(List<User> users)
        {
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(userFilePath, json);
        }

        public List<User> LoadUsers()
        {
            if (File.Exists(userFilePath))
            {
                var json = File.ReadAllText(userFilePath);
                return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            }
            return new List<User>();
        }

        public void SaveContacts(List<Contact> contacts)
        {
            var json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(contactFilePath, json);
        }

        public List<Contact> LoadContacts()
        {
            if (File.Exists(contactFilePath))
            {
                var json = File.ReadAllText(contactFilePath);
                return JsonConvert.DeserializeObject<List<Contact>>(json) ?? new List<Contact>();
            }
            return new List<Contact>();
        }
    }
}


