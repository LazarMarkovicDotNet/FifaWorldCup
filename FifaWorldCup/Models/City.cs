using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifaWorldCup.Models
{
	public class City
	{

        public int Id { get; set; }
        public string CityName { get; set; }
        public virtual ICollection<Stadium> Stadiums { get; set; }


    }
}