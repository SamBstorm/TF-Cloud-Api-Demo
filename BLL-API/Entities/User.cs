using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL_API.Entities
{
    public class User
    {
        private string _email;
        private string _password;
        public Guid UserId { get; set; }
        public string Email { 
            get{
                return _email;
            } 
            set {
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9\-\.+=?]{1,}@[a-zA-Z0-9\-\.+=?]{1,}$")) throw new ArgumentException(nameof(Email), "Email non valide");
                _email = value;
            } 
        }
        public string Password { 
            get{
                return _password;
            }
            set
            {
                if (!Regex.IsMatch(value, "[a-z]{1,}")) throw new ArgumentException(nameof(Password), "Le mot de passe doit contenir une minuscule");
                if (!Regex.IsMatch(value, "[A-Z]{1,}")) throw new ArgumentException(nameof(Password), "Le mot de passe doit contenir une majuscule");
                if (!Regex.IsMatch(value, "[0-9]{1,}")) throw new ArgumentException(nameof(Password), "Le mot de passe doit contenir un chiffre");
                _password = value;
            } 
        }
        public DateTime CreatedAt { get; set; }
        public double AccountAge { 
            get => DateTime.Now.Subtract(CreatedAt).TotalDays;
                }
        public DateTime? DisabledAt { get; set; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public User(DAL_API.Entities.User user) {
            UserId = user.UserId;
            _email = user.Email;
            _password = user.Password;
            CreatedAt = user.CreatedAt;
            DisabledAt = user.DisabledAt;
        }
    }
}
