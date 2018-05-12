using Dapper;
using EMS.Api.DomainModels;
using EMS.Api.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using EMS.Api.Repository.SqlQueries;

namespace EMS.Api.Repository
{
    public class CityRepository : BaseRepository, IRepository<City>
    {
        public IEnumerable<City> Get()
        {
            return SqlMapper.Query<City>((SqlConnection)DbConnection, CityQueries.GetCities, commandType: System.Data.CommandType.Text).ToList();
        }

        public City Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CityID", id);

            return SqlMapper.Query<City>((SqlConnection)DbConnection, CityQueries.GetCity, parameters, commandType: System.Data.CommandType.Text).FirstOrDefault();

        }

        public void Add(City entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CityName", entity.CityName);

            SqlMapper.Execute((SqlConnection)DbConnection, CityQueries.AddCity, parameters, commandType: System.Data.CommandType.Text);
        }

        public void Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CityID", id);

            SqlMapper.Execute((SqlConnection)DbConnection, CityQueries.DeleteCity, parameters, commandType: System.Data.CommandType.Text);

        }

        public void Update(City entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CityID", entity.CityId);
            parameters.Add("@CityName", entity.CityName);

            SqlMapper.Execute((SqlConnection)DbConnection, CityQueries.EditCity, parameters, commandType: System.Data.CommandType.Text);
        }

    }
}
