using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Api.Repository.SqlQueries
{
    public static class CityQueries
    {
        public static readonly string GetCities = @"select CityId, CityName from dbo.City";

        public static readonly string GetCity = @"select CityId, CityName from dbo.City where CityId = @CityID";

        public static readonly string AddCity = @"Insert into dbo.City(CityName) values (@CityName)";

        public static readonly string EditCity = @"Update dbo.City Set CityName = @CityName  Where CityId = @CityID";

        public static readonly string DeleteCity = @"Delete dbo.City where CityId = @CityID";

    }
}
