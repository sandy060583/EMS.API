using System;

namespace EMS.Api.DomainModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }
    }
}
