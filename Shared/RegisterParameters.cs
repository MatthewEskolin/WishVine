using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishVine.Shared
{
    public class RegisterParameters
    {
        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string? PasswordConfirm { get; set; }
    }

    public class RegisterResult
    {
        private RegisterResult(bool success,string message)
        {
            RegisterSuccess = success;
            Error = message ?? string.Empty;
        }


        public static RegisterResult Failure(string message)
        {
            return new RegisterResult(false, message);
        }

        public static RegisterResult Success(string message = null!)
        {
            return new RegisterResult(true, message);
        }
        public bool RegisterSuccess { get; set; }
        public string Error { get; set; }
    }
}
