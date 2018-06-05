using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starcounter.Nova;

namespace NovaSimplePerfTests.Models
{
    [Database]
    public class User
    {
        public virtual string UserName { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string Email { get; set; }
    }
}
