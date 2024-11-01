using System;
using System.Collections.Generic;
using ContactAppMiniProject.Models;
using ContactAppMiniProject.Exceptions;
using ContactAppMiniProject.Services;

namespace ContactAppMiniProject.Controllers
{
    public class ContactController
    {
        private List<Contact> contacts;
        private readonly ContactAppSerialization serialization;

        public ContactController()
        {
            serialization = new ContactAppSerialization();
            contacts = serialization.LoadContacts();
        }

        public void AddContact(Contact newContact)
        {
            if (newContact == null)
            {
                throw new ArgumentNullException(nameof(newContact), "Contact cannot be null.");
            }

            if (contacts.Exists(c => c.ContactID == newContact.ContactID))
            {
                throw new InvalidOperationException("Contact with the same ID already exists.");
            }

            contacts.Add(newContact);
            serialization.SaveContacts(contacts);
        }

        public void ModifyContact(int contactId, Contact updatedContact)
        {
            var contact = FindContactById(contactId);
            if (contact == null)
            {
                throw new UserNotFoundException("Contact not found.");
            }

            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;

            serialization.SaveContacts(contacts);
        }

        public void SoftDeleteContact(int contactId)
        {
            var contact = FindContactById(contactId);
            if (contact == null)
            {
                throw new UserNotFoundException("Contact not found.");
            }

            contact.IsActive = false;
            serialization.SaveContacts(contacts);
        }

        public Contact FindContactById(int contactId)
        {
            return contacts.Find(c => c.ContactID == contactId && c.IsActive);
        }

        public void DisplayAllContacts()
        {
            foreach (var contact in contacts)
            {
                if (contact.IsActive)
                {
                    Console.WriteLine(contact.ToString());
                }
            }
        }
    }
}



