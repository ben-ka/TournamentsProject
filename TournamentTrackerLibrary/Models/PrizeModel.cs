using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentTrackerLibrary.Models
{
    public class PrizeModel
    {
        /// <summary>
        /// The unique id for prize
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Represents the number of the person in the tournament. e.g: 1, 2.
        /// </summary>
        public int PlaceNumber { get; set; }


        /// <summary>
        /// Represents the name of the place of the  person in the tournament. e.g: First, Runner up.
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Represents the amount of money of the price amount for the respective number in the competition.
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Represents the percentage of money of the price amount for the respective number in the competition. Optional
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}
