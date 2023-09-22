using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishVine.Shared
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class LoginResult
    {
        public static LoginResult Failure(string message)
        {
            return new LoginResult()
            {
                LoginSuccess = false,
                Error = message
            };
        }

        
        public static LoginResult Success(string message = null!)
        {
            return new LoginResult()
            {
                LoginSuccess = true,
                Error = message ?? string.Empty
            };
        }
        public bool LoginSuccess { get; set; }
        public string Error { get; set; }
    }
}
