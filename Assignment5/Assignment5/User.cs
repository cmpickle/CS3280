using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    /// <summary>
    /// A class to represent a user object
    /// </summary>
    public class User
    {
        /// <summary>
        /// The user's name
        /// </summary>
        private String name;
        
        public String Name
        { get { return name; } set { name = Name; } }

        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="name"></param>
        public User(String name)
        {
            this.name = name;
        }
    }
}
