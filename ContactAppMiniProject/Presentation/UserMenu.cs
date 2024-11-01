using ContactAppMiniProject.Controllers;
using ContactAppMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppMiniProject.Presentation
{
    public class UserMenu
    {
        private UserController userController;

        public UserMenu(UserController userController)
        {
            userController = new UserController();
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("User Menu:");
                Console.WriteLine("1. Add New User");
                Console.WriteLine("2. Modify Existing User");
                Console.WriteLine("3. Delete User ");
                Console.WriteLine("4. Display All Users");
                Console.WriteLine("5. Find User by ID");
                Console.WriteLine("6. Logout");

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddNewUser();
                            break;
                        case "2":
                            ModifyUser();
                            break;
                        case "3":
                            SoftDeleteUser();
                            break;
                        case "4":
                            userController.DisplayAllUsers();
                            break;
                        case "5":
                            FindUserById();
                            break;
                        case "6":
                            return; // Exit User Menu
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

        public void AddNewUser()
        {
            Console.WriteLine("Enter User ID:");
            int userId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Is Admin? (true/false):");
            bool isAdmin = bool.Parse(Console.ReadLine());

            Console.WriteLine("Is Active? (true/false):"); 
            bool isActive = bool.Parse(Console.ReadLine());

            User newUser = new User(userId, firstName, lastName, isAdmin, isActive);
            userController.AddUser(newUser);
            Console.WriteLine("User created successfully.");
        }

        public void ModifyUser()
        {
            Console.WriteLine("Enter User ID to modify:");
            int userId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter New First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter New Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Is Admin? (true/false):");
            bool isAdmin = bool.Parse(Console.ReadLine());

            Console.WriteLine("Is Active? (true/false):");  
            bool isActive = bool.Parse(Console.ReadLine());

            User updatedUser = new User(userId, firstName, lastName, isAdmin, isActive);

            userController.ModifyUser(userId, updatedUser);
            Console.WriteLine("User modified successfully.");
        }

        public void SoftDeleteUser()
        {
            Console.WriteLine("Enter User ID to delete:");
            int userId = int.Parse(Console.ReadLine());
            userController.SoftDeleteUser(userId);
            Console.WriteLine("User deleted successfully.");
        }

        public void FindUserById()
        {
            Console.WriteLine("Enter User ID to find:");
            int userId = int.Parse(Console.ReadLine());
            var user = userController.FindUserById(userId);
            if (user != null)
            {
                Console.WriteLine(user.ToString());
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }
    }
}

