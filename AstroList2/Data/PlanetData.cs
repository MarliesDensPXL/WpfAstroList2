using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroList2.Models;

namespace AstroList2.Data
{
    public static class PlanetData
    {
        static List<Planet> planets = new List<Planet>
    {
        new Planet
        {
            Name = "Mercurius",
            Size = "Small",
            TemperatureInCelcius = 167,
            HasRings = false,
            HasAtmosphere = false,
            NumberOfMoons = 0,
            DistanceFromSunInKm = 57900000,
            ImageName = "mercury.png"
        },
        new Planet
        {
            Name = "Venus",
            Size = "Medium",
            TemperatureInCelcius = 464,
            HasRings = false,
            HasAtmosphere = true,
            NumberOfMoons = 0,
            DistanceFromSunInKm = 108200000,
            ImageName = "venus.png"
        },
        new Planet
        {
            Name = "Aarde",
            Size = "Medium",
            TemperatureInCelcius = 15,
            HasRings = false,
            HasAtmosphere = true,
            NumberOfMoons = 1,
            DistanceFromSunInKm = 149600000,
            ImageName = "earth.png"
        },
        new Planet
        {
            Name = "Mars",
            Size = "Small",
            TemperatureInCelcius = -65,
            HasRings = false,
            HasAtmosphere = true,
            NumberOfMoons = 2,
            DistanceFromSunInKm = 227900000,
            ImageName = "mars.png"
        },
        new Planet
        {
            Name = "Jupiter",
            Size = "Large",
            TemperatureInCelcius = -110,
            HasRings = true,
            HasAtmosphere = true,
            NumberOfMoons = 79,
            DistanceFromSunInKm = 778500000,
            ImageName = "jupiter.png"
        },
        new Planet
        {
            Name = "Saturnus",
            Size = "Large",
            TemperatureInCelcius = -140,
            HasRings = true,
            HasAtmosphere = true,
            NumberOfMoons = 82,
            DistanceFromSunInKm = 1434000000,
            ImageName = "saturn.png"
        },
        new Planet
        {
            Name = "Uranus",
            Size = "Large",
            TemperatureInCelcius = -195,
            HasRings = true,
            HasAtmosphere = true,
            NumberOfMoons = 27,
            DistanceFromSunInKm = 2871000000,
            ImageName = "uranus.png"
        },
        new Planet
        {
            Name = "Neptunus",
            Size = "Large",
            TemperatureInCelcius = -200,
            HasAtmosphere = true,
            HasRings = true,
            NumberOfMoons = 14,
            DistanceFromSunInKm = 4495000000,
            ImageName = "neptune.png"
        }
    };
        static Random rng = new Random();
        public static List<Planet> GetPlanetsInRandomOrder()
        {
            return planets.OrderBy(p => rng.Next()).ToList();
        }
    }
}
