using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCommonLibrary.Models
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
