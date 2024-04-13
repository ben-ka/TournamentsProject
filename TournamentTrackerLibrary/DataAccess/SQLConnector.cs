using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentTrackerLibrary.Models;
using TournamentTrackerLibrary.DataAccess;
using System.Data.SqlClient;
using Dapper;
using System.Reflection;

//@PlaceNumber int,
//@PlaceName nvarchar(50),
//@PrizeAmount money,
//@PrizePercentage float,
//@Id int = 0 output


namespace TournamentTrackerLibrary
{
    public class SQLConnector : IDataConnection
    {
        private const string DbName = "Tournaments";



        /// <summary>
        /// Saves a prize including it's id to the database
        /// </summary>
        /// <param name="model">the prize information from the form</param>
        /// <returns>The new prize information including a Id</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(DbName)))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
          
                connection.Execute("dbo.spPrizes_CreatePrize", p);

                model.Id = p.Get<int>("@Id");

                return model;
            }

        }

        public PersonModel CreatePerson(PersonModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(DbName)))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@EmailAddress", model.EmailAdress);
                p.Add("@PhoneNumber", model.PhoneNumber);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_CreatePerson", p);

                model.Id = p.Get<int>("@Id");

                return model;
            }
        }

        public List<PersonModel> GetAllPerson()
        {
            List<PersonModel> output;
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(DbName)))
            {
                output = connection.Query<PersonModel>("dbo.spPeople_GetAll").ToList();
            }
            return output;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            using (IDbConnection connection = new SqlConnection(GlobalConfig.CnnString(DbName)))
            {
                var p = new DynamicParameters();
                p.Add("@TeamName", model.TeamName);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_CreateTeam", p);

                model.Id = p.Get<int>("@Id");

                foreach (PersonModel person in model.TeamMembers)
                {
                    var d = new DynamicParameters();
                    d.Add("@TeamId", model.Id);
                    d.Add("PersonId",  person.Id);
                    connection.Execute("dbo.spTeamMembers_CreateTeamMember", d);
                }

                return model;
            }
        }


    }

         
}
