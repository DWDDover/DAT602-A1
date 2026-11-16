using System;
using System.Collections.Generic;
using System.Text;

namespace mousegame
{
    public class LoginResult : Result
    {
        public int? UserId { get; set; }

        public int? Admin { get; set; }
    }
}
