using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTrackerLibrary.Models
{
    public class MatchupModel
    {
        /// <summary>
        /// Represents the two teams competing in a matchup.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; }
        
        /// <summary>
        /// Represents the team that won the matchup.
        /// </summary>
        public TeamModel Winner {  get; set; }


        /// <summary>
        /// Represent the round of the matchup.
        /// Meaning what rounf this matchup was played.
        /// </summary>
        public int MatchupRound { get; set; }

        public MatchupModel()
        {
            Entries = new List<MatchupEntryModel>();
        }

        


    }
}
