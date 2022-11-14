using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDBOP
{
    public  class Facility
    {
        public int Facility_id { get; set; }
        public string Facility_name { get; set; }

        public override string ToString() {
            return $"ID {Facility_id}, Name {Facility_name}";
        }
    }
}
