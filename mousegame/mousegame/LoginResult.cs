using System;
using System.Collections.Generic;
using System.Text;

namespace mousegame
{
    public class LoginResult
    {
        public string Status { get; set; }
        public int? UserId { get; set; }

        public int? Admin { get; set; }
    }
}
