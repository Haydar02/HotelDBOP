using System;
using System.Collections.Generic;
using System.Text;

namespace HotelDBOP
{
    public  class HotelFacility
    {
        public int id { get; set; }
        public int Facility_id { get; set; }
        public int Hotel_No { get; set; }

        public override string ToString() 
        {
            return $"ID:{id},Facility ID  {Facility_id}, Hotel NO {Hotel_No}";   
        }
    }
}
