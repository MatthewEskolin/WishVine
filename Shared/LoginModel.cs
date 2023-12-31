﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudBlazor;

namespace WishVine.Shared
{
    public class LoginModel
    {
        [Required] public string UserName { get; set; } = null!;

        [Required] public string Password { get; set; } = null!;

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
        public static LoginResult Success()
        {
            return Success(string.Empty);
        }
        public static LoginResult Success(string message)
        {
            return new LoginResult()
            {
                LoginSuccess = true,
                Error = message ?? string.Empty
            };
        }
        public bool LoginSuccess { get; private init; }
        public string Error { get; private init; } = string.Empty;
    }


    
}
