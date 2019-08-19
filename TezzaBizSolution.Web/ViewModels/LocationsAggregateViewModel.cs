using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TezzaBizSolution.Lib.Models;

namespace TezzaBizSolution.Web.ViewModels
{
    public class LocationsAggregateViewModel
    {
        public List<Collection> Collections { get; set; }
        public List<Location> Locations { get; set; }
    }
}
