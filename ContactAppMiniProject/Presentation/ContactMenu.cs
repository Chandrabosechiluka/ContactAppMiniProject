using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAppMiniProject.Controllers;
using ContactAppMiniProject.Models;

namespace ContactAppMiniProject.Presentation
{
    public class ContactMenu
    {
        private ContactController contactController;

        public ContactMenu(ContactController contactController)
        {
            contactController = new ContactController();
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("Contact Menu:");
                Console.WriteLine("1. Add New Contact");
                Console.WriteLine("2. Modify Existing Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. Display All Contacts");
                Console.WriteLine("5. Find Contact by ID");
                Console.WriteLine("6. Logout");

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddNewContact();
                            break;
                        case "2":
                            ModifyContact();
                            break;
                        case "3":
                            SoftDeleteContact();
                            break;
                        case "4":
                            contactController.DisplayAllContacts();
                            break;
                        case "5":
                            FindContactById();
                            break;
                        case "6":
                            return; 
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void AddNewContact()
        {
            Console.WriteLine("Enter Contact ID:");
            int contactId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Is Active? (true/false):");
            bool isActive = bool.Parse(Console.ReadLine());

            
            Contact newContact = new Contact(contactId, firstName, lastName, isActive);
            contactController.AddContact(newContact);
            Console.WriteLine("Contact created successfully.");
        }

        public void ModifyContact()
        {
            Console.WriteLine("Enter Contact ID to modify:");
            int contactId = int.Parse(Console.ReadLine());

            Contact existingContact = contactController.FindContactById(contactId);
            if (existingContact == null)
            {
                Console.WriteLine("Contact not found.");
                return;
            }

            Console.WriteLine($"Current First Name: {existingContact.FirstName}");
            Console.WriteLine("Enter new First Name (leave blank to keep current):");
            string firstName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(firstName))
            {
                existingContact.FirstName = firstName;
            }

            Console.WriteLine($"Current Last Name: {existingContact.LastName}");
            Console.WriteLine("Enter new Last Name (leave blank to keep current):");
            string lastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                existingContact.LastName = lastName;
            }

            Console.WriteLine($"Current Active Status: {existingContact.IsActive}");
            Console.WriteLine("Is Active? (true/false, leave blank to keep current):");
            string isActiveInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(isActiveInput) && bool.TryParse(isActiveInput, out bool isActive))
            {
                existingContact.IsActive = isActive;
            }

            //contactController.ModifyContact(existingContact);
            Console.WriteLine("Contact updated successfully.");
        }

        public void SoftDeleteContact()
        {
            Console.WriteLine("Enter Contact ID to delete:");
            int contactId = int.Parse(Console.ReadLine());
            contactController.SoftDeleteContact(contactId);
            Console.WriteLine("Contact marked as deleted.");
        }

        public void FindContactById()
        {
            Console.WriteLine("Enter Contact ID to find:");
            int contactId = int.Parse(Console.ReadLine());
            Contact foundContact = contactController.FindContactById(contactId);
            Console.WriteLine(foundContact != null ? foundContact.ToString() : "Contact not found.");
        }
    }
}

