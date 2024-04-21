using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityTestApi.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Handle { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string City { get; set; }
    }
}