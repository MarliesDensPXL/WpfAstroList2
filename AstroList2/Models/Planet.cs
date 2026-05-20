using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroList2.Models
{
    public class Planet
    {
        public long DistanceFromSunInKm { get; set; }

        public bool HasAtmosphere { get; set; }

        public bool HasMoons 
        {
            get { return (NumberOfMoons > 0); }
        }

        public bool HasRings { get; set; }

        public string ImageName { get; set; }

        public string Name { get; set; }

        public int NumberOfMoons { get; set; }

        public string Size { get; set; }

        public int TemperatureInCelcius { get; set; }

        public int CalculateTravelTimeFromSunToPlanetInDays(long speedInKmPerHour)
        {
            long hours = DistanceFromSunInKm / speedInKmPerHour;
                int days = (int)hours/24;
            return days;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
