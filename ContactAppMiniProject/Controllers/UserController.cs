using System;
using System.Collections.Generic;
using ContactAppMiniProject.Models;
using ContactAppMiniProject.Exceptions;
using ContactAppMiniProject.Services;

namespace ContactAppMiniProject.Controllers
{
    public class UserController
    {
        private List<User> users;
        private readonly ContactAppSerialization serialization;

        public UserController()
        {
            serialization = new ContactAppSerialization();
            users = serialization.LoadUsers();
        }

        public void AddUser(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser), "User cannot be null.");
            }

            if (users.Exists(u => u.UserID == newUser.UserID))
            {
                throw new InvalidOperationException("User with the same ID already exists.");
            }

            users.Add(newUser);
            serialization.SaveUsers(users);
        }

        public void ModifyUser(int userId, User updatedUser)
        {
            var user = FindUserById(userId);
            if (user == null)
            {
                throw new UserNotFoundException("User not found.");
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.IsAdmin = updatedUser.IsAdmin;
            user.IsActive= updatedUser.IsActive;

            serialization.SaveUsers(users);
        }

        public void SoftDeleteUser(int userId)
        {
            var user = FindUserById(userId);
            if (user == null)
            {
                throw new UserNotFoundException("User not found.");
            }

            user.IsActive = false;
            serialization.SaveUsers(users);
        }

        public User FindUserById(int userId)
        {
            return users.Find(u => u.UserID == userId && u.IsActive);
        }

        public void DisplayAllUsers()
        {
            foreach (var user in users)
            {
                if (user.IsActive)
                {
                    Console.WriteLine(user.ToString());
                }
            }
        }
    }
}


