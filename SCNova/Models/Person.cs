using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starcounter.Nova;

namespace SCNova.Models
{
    [Database]
    public abstract class Person
    {
        public abstract string FirstName { get; set; }
        public abstract string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }
}
