using Dapper;
using EMS.Api.DomainModels;
using EMS.Api.Interfaces;
using EMS.Api.Repository.SqlQueries;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EMS.Api.Repository
{
    public class EmployeeRepository : BaseRepository, IRepository<Employee>
    {
        public Employee Get(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", id);
            return SqlMapper.Query<Employee>((SqlConnection)DbConnection, EmployeeQueries.GetEmployee, parameters, commandType: System.Data.CommandType.Text).FirstOrDefault();

        }

        public IEnumerable<Employee> Get()
        {
            return SqlMapper.Query<Employee>((SqlConnection)DbConnection, EmployeeQueries.GetEmployees, commandType: System.Data.CommandType.Text).ToList();
        }


        public void Add(Employee entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeName", entity.EmployeeName);
            parameters.Add("@CityID", entity.CityId);
            SqlMapper.Execute((SqlConnection)DbConnection, EmployeeQueries.AddEmployee, parameters, commandType: System.Data.CommandType.Text);
        }

        public void Delete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", id);
            SqlMapper.Execute((SqlConnection)DbConnection, EmployeeQueries.DeleteEmployee, parameters, commandType: System.Data.CommandType.Text);

        }

        public void Update(Employee entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", entity.EmployeeId);
            parameters.Add("@EmployeeName", entity.EmployeeName);
            parameters.Add("@CityID", entity.CityId);
            SqlMapper.Execute((SqlConnection)DbConnection, EmployeeQueries.EditEmployee, parameters, commandType: System.Data.CommandType.Text);
        }
    }
}
