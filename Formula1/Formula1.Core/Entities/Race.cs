using System;
using System.Collections.Generic;


namespace Formula1.Core.Entities
{
    public class Race
    {
        public string City { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; internal set; }
        public string Country { get; internal set; }
    }
}
