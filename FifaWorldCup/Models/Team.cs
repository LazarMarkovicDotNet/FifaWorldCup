using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FifaWorldCup.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public virtual ICollection<Stadium> StadiumsTeam { get; set; }

    }
}