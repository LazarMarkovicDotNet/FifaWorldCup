using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifaWorldCup.Models
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Capacity { get; set; }
        public string StadiumName { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}