using System;
using System.Collections.Generic;
using System.Text;

namespace TezzaBizSolution.Lib.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Collection Collection { get; set; }
    }
}
