using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DocumentDb.Model
{
    public class Address
    {
        public string RoadName { get; set; }

        public int HouseNumber { get; set; }

        public City City { get; set; }

        public Address(string roadName, int houseNumber, City city)
        {
            RoadName = roadName;
            HouseNumber = houseNumber;
            City = city;
        }

        protected Address()
        { }

    }
}