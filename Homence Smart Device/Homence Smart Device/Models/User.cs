using System;
using System.Collections.Generic;
using System.Text;

namespace Homence_Smart_Device.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri Picture { get; set; }

    }
    public interface IGoogleManager
    {
        void Login(Action<User, string> OnLoginComplete);

        void Logout();
    }
}
