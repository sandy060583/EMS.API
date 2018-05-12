using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Api.Repository.SqlQueries
{
    public static class EmployeeQueries
    {

        public static readonly string GetEmployees = @"select EmployeeId, EmployeeName, emp.CityId, city.CityName
                                from dbo.Employee emp
                                left join dbo.City city on emp.CityId = city.CityId";


        public static readonly string GetEmployee = @"select EmployeeId, EmployeeName, emp.CityId, city.CityName
                                from dbo.Employee emp
                                left join dbo.City city on emp.CityId = city.CityId
                                where EmployeeId = @EmployeeID";



        public static readonly string AddEmployee = @"Insert into dbo.Employee(EmployeeName, CityId)
                            values (@EmployeeName, @CityID)";

        public static readonly string EditEmployee = @"Update dbo.Employee
                                 Set EmployeeName = @EmployeeName, CityId = @CityID
                                 Where EmployeeId = @EmployeeID";


        public static readonly string DeleteEmployee = @"Delete dbo.Employee where EmployeeId = @EmployeeID";

    }
}
