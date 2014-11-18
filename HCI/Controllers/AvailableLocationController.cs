using HCI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HCI.Controllers
{
    public class AvailableLocationController : ApiController
    {
        public IList<LocationEntity> Get(string startDate, string endDate, string startTime,
                                         string endTime, string intervalType, string occurDays, 
                                         string neverEnds)
        {
            List<LocationEntity> list = new List<LocationEntity>();
            list.Add(new LocationEntity { ID = 0, Name = "To be determined" });
            list.Add(new LocationEntity { ID = 1, Name = "Room 1" });
            list.Add(new LocationEntity { ID = 2, Name = "Room 2" });

            return list;
        }

        public IList<LocationEntity> Get(string startDate, string endDate)
        {
            List<LocationEntity> list = new List<LocationEntity>();
            return list;
        }
    }

}
