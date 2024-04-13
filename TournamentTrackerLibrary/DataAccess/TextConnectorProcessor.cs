using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TournamentTrackerLibrary.Models;
using System.Reflection.Metadata.Ecma335;

namespace TournamentTrackerLibrary.DataAccess.TextConnecting
{
    public static class TextConnectorProcessor
    {
        /// <summary>
        /// Returns the full path file using the App.Config file as the the base file and input as the ending text file path
        /// </summary>
        /// <param name="fileName">gets the text file end path (not including the base path)</param>
        /// <returns>the full path for the text file</returns>
        public static string FullFilePath(string fileName) 
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        /// <summary>
        /// The function reads the data from the file path and returns it's content as a list of string
        /// </summary>
        /// <param name="file">gets the full path of the file </param>
        /// <returns>a list of type strings where each place represents a row of data from the file. If the file doesn't exist returns an empty list.</returns>
        public static List<string> LoadFile(string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        } 

        /// <summary>
        /// The function gets a list of strings that represents the contents of the file and returns a list of prize models which match the data from the file.
        /// </summary>
        /// <param name="lines">Gets a list of strings which represents the contents of the file</param>
        /// <returns>A list of prize models which coincides with the text file data. If the input is an empty array, will return an empty list of objects.</returns>
        public static List<PrizeModel> ConvertToPrizeModels(List<string> lines)
        {
            List<PrizeModel> prizeModels = new List<PrizeModel>();
            foreach (string line in lines) 
            {
                
                string[] cols = line.Split(',');
                PrizeModel p = new PrizeModel();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                prizeModels.Add(p);
            }
            return prizeModels;
        }
        /// <summary>
        /// Gets the models as a list of PrizeModels and a file name and converts the prize models data into a list of string and writes it to the text file
        /// given as input.
        /// </summary>
        /// <param name="models">Represents all of the prize models as a list of PrizeModels</param>
        /// <param name="fileName">Represents the last part of the file path</param>
        public static void SaveToPrizeFile(List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach(PrizeModel p in models)
            {
                string line = $"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}";
                lines.Add(line);
                
            }
            File.WriteAllLines(FullFilePath(fileName), lines);
        }


        public static List<PersonModel> ConvertToPersonModel(List<string> lines)
        {
            List<PersonModel> people = new List<PersonModel>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                PersonModel p = new PersonModel();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.EmailAdress = cols[3];
                p.PhoneNumber = cols[4];
                people.Add(p);
            }
            return people; 
        }

        public static void SaveToPeopleFile(List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (PersonModel p in models)
            {
                string line = $"{p.Id},{p.FirstName},{p.LastName},{p.EmailAdress},{p.PhoneNumber}";
                lines.Add(line);
            }
            File.WriteAllLines (FullFilePath(fileName), lines);
        }

        public static List<TeamModel> ConvertToTeamModel(List<string> textData, string peoplefileName)
        {
            List<TeamModel> teams = new List<TeamModel>();

            string fullFilePath = FullFilePath(peoplefileName);
            List<string> PeopletextData = LoadFile(fullFilePath);

            //convert the text data into a list of prizes
            List<PersonModel> people = ConvertToPersonModel(PeopletextData);

            foreach (string line in textData)
            {
                // id, team name, people id's seperated with a |
                // 3,Ben's team,3|5|4|2|8

                string[] cols = line.Split(",");
                TeamModel team = new TeamModel();
                team.Id = int.Parse(cols[0]);
                team.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string  id in personIds)
                {
                    team.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }
                teams.Add(team);
            }
            return teams;
        }

        public static void SaveToTeamsFile(List<TeamModel> teams, string fileName)
        {
            List<string> lines = new List<string> ();
            foreach(TeamModel team in teams) 
            {
                
                string peopleIdsString = "";
                
                foreach (PersonModel person in team.TeamMembers)
                {            
                    peopleIdsString += $"{person.Id}|";                     
                }
                peopleIdsString = peopleIdsString.Substring(0, peopleIdsString.Length - 1);
                string line = $"{team.Id},{team.TeamName},{peopleIdsString}";
                lines.Add(line);
            }

            File.WriteAllLines(FullFilePath(fileName), lines);
        }
    }
}
