using ContactAppMiniProject.Controllers;
using ContactAppMiniProject.Exceptions;
using ContactAppMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactAppMiniProject.Presentation;

namespace ContactAppMiniProject.Presentation
{
    public class MainMenu
    {
        private UserController userController;
        private ContactController contactController;
        private UserMenu userMenu;
        private ContactMenu contactMenu;

        public MainMenu()
        {
            userController = new UserController();
            contactController = new ContactController();
            userMenu = new UserMenu(userController);
            contactMenu = new ContactMenu(contactController);
        }

        public void Display()
        {
            Console.WriteLine("Menu:");
            Console.Write("Enter UserId: ");
            int userId;

           
            while (!int.TryParse(Console.ReadLine(), out userId))
            {
                Console.WriteLine("Invalid input. Please enter a valid User ID.");
                Console.Write("Enter UserId: ");
            }

            User user = userController.FindUserById(userId);
            if (user == null)
            {
                CreateNewUser(userId);
                return; 
            }

            if (!user.IsActive)
            {
                Console.WriteLine("User is not active.");
                return;
            }

            if (user.IsAdmin)
            {
                DisplayAdminSubMenu();
            }
            else
            {
                DisplayUserSubMenu();
            }
        }

        private void CreateNewUser(int userId)
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Is Admin (true/false): ");
            bool isAdmin;
            while (!bool.TryParse(Console.ReadLine(), out isAdmin))
            {
                Console.WriteLine("Invalid input. Please enter true or false.");
                Console.Write("Is Admin (true/false): ");
            }

            User newUser = new User(userId, firstName, lastName, isAdmin, true);
            userController.AddUser(newUser); 

            Console.WriteLine("New user created successfully.");
            DisplayUserSubMenu(); 
        }

        private void DisplayAdminSubMenu()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("What do you wish to do?");
            Console.WriteLine("1. Add new User");
            Console.WriteLine("2. Modify existing user");
            Console.WriteLine("3. Delete user (soft)");
            Console.WriteLine("4. Display all users");
            Console.WriteLine("5. Find user by ID");
            Console.WriteLine("6. Logout");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    userMenu.AddNewUser();
                    break;
                case "2":
                    userMenu.ModifyUser();
                    break;
                case "3":
                    userMenu.SoftDeleteUser();
                    break;
                case "4":
                    userController.DisplayAllUsers();
                    break;
                case "5":
                    userMenu.FindUserById();
                    break;
                case "6":
                    Console.WriteLine("Logging out...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void DisplayUserSubMenu()
        {
            Console.WriteLine("User Menu:");
            Console.WriteLine("What do you wish to do?");
            Console.WriteLine("1. Work on Contacts");
            Console.WriteLine("    1.1 Add new Contact");
            Console.WriteLine("    1.2 Modify existing Contact");
            Console.WriteLine("    1.3 Delete (soft) Contact");
            Console.WriteLine("    1.4 Display all Contacts");
            Console.WriteLine("    1.5 Find Contact by ID");
            Console.WriteLine("    1.6 Logout");
            Console.WriteLine("2. Work on Contact Details");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    HandleContactSubMenu();
                    break;
                case "2":
                    Console.WriteLine("Contact Details logic not implemented yet.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

        private void HandleContactSubMenu()
        {
            Console.WriteLine("Contact Menu:");
            Console.WriteLine("1. Add new Contact");
            Console.WriteLine("2. Modify existing Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Display all Contacts");
            Console.WriteLine("5. Find Contact by ID");
            Console.WriteLine("6. Logout");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    contactMenu.AddNewContact();
                    break;
                case "2":
                    contactMenu.ModifyContact();
                    break;
                case "3":
                    contactMenu.SoftDeleteContact();
                    break;
                case "4":
                    contactController.DisplayAllContacts();
                    break;
                case "5":
                    contactMenu.FindContactById();
                    break;
                case "6":
                    Console.WriteLine("Logging out...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

