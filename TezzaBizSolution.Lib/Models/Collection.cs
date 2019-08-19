using System;
using System.Collections.Generic;
using System.Text;

namespace TezzaBizSolution.Lib.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
