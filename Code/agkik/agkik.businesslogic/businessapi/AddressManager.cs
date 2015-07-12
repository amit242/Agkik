using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using agkik.businesslogic.models;
using log4net;
using System.Reflection;
using System.Data;

namespace agkik.businesslogic.businessapi
{
    public class AddressManager
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static List<City> getCities()
        {
            AgkikdbEntities entity = new AgkikdbEntities();

            
            var cities = (from a in entity.addresses
                          select new { name = a.City, state = a.State, country = a.Country }).Distinct().OrderBy(x => x);
            try
            {
                List<City> ret = new List<City>();
                foreach (var city in cities)
                {
                    log.Debug(string.Format("city[{0}],state[{1}],country[{2}]", city.name, city.state, city.country));

                    ret.Add(new City()
                    {
                        CityName = city.name,
                        State = city.state,
                        Country = city.country
                    });
                }
                return ret;
            }
            catch (EntityException ex)
            {
                log.Fatal("Database connection error", ex);
            }
            return null;
        }
    }
}
