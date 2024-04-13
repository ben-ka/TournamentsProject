using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerLibrary.Models;
using TournamentTrackerLibrary.DataAccess.TextConnecting;

namespace TournamentTrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";
        private const string PeopleFile = "PeopleModels.csv";
        private const string TeamFile = "TeamModels.csv";

        /// <summary>
        /// Saves a prize including it's id to the text file
        /// </summary>
        /// <param name="model">the prize information from the form</param>
        /// <returns>The new prize information including a Id</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //load the text file 
            string fullFilePath = TextConnectorProcessor.FullFilePath(PrizesFile);
            List<string> textData = TextConnectorProcessor.LoadFile(fullFilePath);

            //convert the text data into a list of prizes
            List<PrizeModel> prizes = TextConnectorProcessor.ConvertToPrizeModels(textData);

            //find the max Id
            int currentId = 0;
            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            
            model.Id = currentId;
            // add the new prize record with the new Id
            prizes.Add(model);

            //converts the prizes list to a string list and saves it in the specified file name
            TextConnectorProcessor.SaveToPrizeFile(prizes, PrizesFile);

            return model;
        }


        public PersonModel CreatePerson(PersonModel model)
        {
            string fullFilePath = TextConnectorProcessor.FullFilePath(PeopleFile);
            List<string> textData = TextConnectorProcessor.LoadFile(fullFilePath);

            //convert the text data into a list of prizes
            List<PersonModel> people = TextConnectorProcessor.ConvertToPersonModel(textData);

            //find the max Id
            int currentId = 0;
            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;
            // add the new people record with the new Id
            people.Add(model);

            //converts the people list to a string list and saves it in the specified file name
            TextConnectorProcessor.SaveToPeopleFile(people, PeopleFile);

            return model;
        }

        public List<PersonModel> GetAllPerson()
        {
            string fullFilePath = TextConnectorProcessor.FullFilePath(PeopleFile);
            List<string> textData = TextConnectorProcessor.LoadFile(fullFilePath);

            //convert the text data into a list of prizes
            List<PersonModel> people = TextConnectorProcessor.ConvertToPersonModel(textData);
            return people;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            string fullFilePath = TextConnectorProcessor.FullFilePath(TeamFile);
            List<string> textData = TextConnectorProcessor.LoadFile(fullFilePath);

            //convert the text data into a list of prizes
            List<TeamModel> teams = TextConnectorProcessor.ConvertToTeamModel(textData, PeopleFile);

            //find the max Id
            int currentId = 0;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;
            // add the new people record with the new Id
            teams.Add(model);
            TextConnectorProcessor.SaveToTeamsFile(teams, TeamFile);
            return model;
        }
    }
}
