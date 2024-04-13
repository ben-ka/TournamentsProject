using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerLibrary.Models;

namespace TournamentTrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel prize);

        PersonModel CreatePerson(PersonModel person);

        List<PersonModel> GetAllPerson();

        TeamModel CreateTeam(TeamModel model);


    }
}
