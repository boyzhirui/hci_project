using HCI.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCI.Models
{
    public class LocationModel : ModelBase
    {
        public LocationModel()
        {

        }

        public LocationModel(HciDb ctx):base(ctx)
        {

        }

        public IList<LocationEntity> LocationList { get; set; }

        public void GetAvailableLocations(DateTime startDate, DateTime endDate, TimeSpan startTime, 
                                          TimeSpan endTime, string intervalType, string occurDays, 
                                          bool neverEnds)
        {
            LocationList = new List<LocationEntity>();

            //Context.Locations
        }

    }

    public class LocationEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}