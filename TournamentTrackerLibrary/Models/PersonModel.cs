using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTrackerLibrary.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Represents the person's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Represents the person's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represents the person's email address.
        /// </summary>
        public string EmailAdress { get; set; }

        /// <summary>
        /// Represents the person's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }    
        }
        


    }
}
