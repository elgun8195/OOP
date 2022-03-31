using GeneralPractice.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Utils.Enums;

namespace GeneralPractice.Models
{
    internal class User : IEntity
    {
        private static int _id;
        public int Id { get; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public User(Role role,string username,string email)
        {
            _id++;
            Id = _id;
            Username = username;
            Email = email;
            Role = role;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Id: {Id} - Username: {Username} - Email: {Email} - Role: {Role}");
        }
    }
}
