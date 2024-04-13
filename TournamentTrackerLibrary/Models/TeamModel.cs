using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTrackerLibrary.Models
{
    public class TeamModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Represents the team's name
        /// </summary>
        public string TeamName { get; set; }


        /// <summary>
        /// Represents a list of players in a single team. could be singles meaning only one Person object in the list.
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; }

        public TeamModel()  
        {
            TeamMembers = new List<PersonModel>();
        }

    }
}
