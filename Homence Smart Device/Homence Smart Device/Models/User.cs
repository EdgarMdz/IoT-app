using System;
using System.Collections.Generic;
using System.Text;

namespace Homence_Smart_Device.Models
{
    public class User : BaseModel
    {
        private string name;
        private string email;
        private Uri picture;

        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public string Email { get => email; set { email = value; OnPropertyChanged(); } }
        public Uri Picture { get => picture; set { picture = value; OnPropertyChanged(); } }
    }
    public interface IGoogleManager
    {
        void Login(Action<User, string> OnLoginComplete);

        void Logout();
    }
}
