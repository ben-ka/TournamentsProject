using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTrackerLibrary.Models
{
    public class TournamentModel
    {

        /// <summary>
        /// Represents the tournament's name
        /// </summary>
        public string  TournamentName { get; set; }

        /// <summary>
        /// Represents a list of all of the teams in the tournament.
        /// </summary>
        public List<TeamModel> TeamsParticipating  { get; set; }

        /// <summary>
        /// Represents the necessary entry fee for every team in the tournament.
        /// </summary>
        public decimal EntryFee {  get; set; }

        /// <summary>
        /// Represents a list of prizes in the tournament.
        /// </summary>
        public List<PrizeModel> Prizes { get; set; }

        /// <summary>
        /// Represent's a list of all of the matchups in the tournament. Each list inside the list is a separate round.
        /// </summary>
        public List<List<MatchupModel>> Rounds { get; set; }

        public TournamentModel()
        {
            TeamsParticipating = new List<TeamModel>();
            Prizes = new List<PrizeModel>();
            Rounds = new List<List<MatchupModel>>();
        }
    }
}
