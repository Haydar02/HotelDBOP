using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;


namespace HotelDBOP
{
    public  class ServiceHotelFacility
    {

        string connectionString =@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        private int GetMaxHotelId(SqlConnection connection)
        {
            string queryAllHotel = "SELECT * FROM DemoHotel";
            Console.WriteLine(queryAllHotel);
            SqlCommand command = new SqlCommand(queryAllHotel, connection);
            SqlDataReader reader = command.ExecuteReader();
            int result = 0;
            while (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            reader.Close();
            Console.WriteLine($"Max Hotel Id :{result}");
            return result;
        }
        private List<Hotel> ListAllHotel(SqlConnection connection) {

            string queryStringAllHotel = "Select * from DemoHotel";
            Console.WriteLine(queryStringAllHotel);
            SqlCommand query = new SqlCommand(queryStringAllHotel, connection);
            SqlDataReader reader = query.ExecuteReader();
            Console.WriteLine("List Alle HotelFacilites");
            if (!reader.Read())
            {
                Console.WriteLine("No Hotelin database");
                reader.Close();
                return null;
            }
            List<Hotel> hotels = new List<Hotel>();
            while (reader.Read())
            {
                Hotel nextHotel= new Hotel()
                {
                    Hotel_No = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Address = reader.GetString(2)

                };
                hotels.Add(nextHotel);
                Console.WriteLine(nextHotel);
            }
            reader.Close();
            Console.WriteLine();
            return hotels;
        }

        private Hotel GetHotel(SqlConnection connection, int Hotel_No) {
            string queryStringHotel= $"SELECT  * from DemoHotel where Hotel_No ={Hotel_No}";
            Console.WriteLine(queryStringHotel);
            SqlCommand query = new SqlCommand(queryStringHotel, connection);
            SqlDataReader reader = query.ExecuteReader();

            Console.WriteLine($"{Hotel_No}");

            if (!reader.HasRows)
            {
                Console.WriteLine("No Hotel in database");
                reader.Close();
                return null;
            }
            Hotel hotel = null;

            if (reader.Read())
            {
                hotel= new Hotel()
                {
                    Hotel_No= reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Address = reader.GetString(2)
                };
                Console.WriteLine(hotel);
            }
            reader.Close();
            Console.WriteLine();
            return hotel;

        }

        private int GetMaxFacilityId(SqlConnection connection)
        {

            string queryStringAllFacility = "SELECT MAX(Facility_id) FROM Facility";
            Console.WriteLine(queryStringAllFacility);
            SqlCommand command= new SqlCommand(queryStringAllFacility, connection);
            SqlDataReader reader = command.ExecuteReader();
            int result = 0;
            if(reader.Read())
            {
                result = reader.GetInt32(0);
            }
            reader.Close();
            Console.WriteLine($"Max Facility ID:{result}");
            return result;
        }
        

        private int CreateFacility(SqlConnection connection, Facility facility) 
        {
            Console.WriteLine("Create Facility");
            string insertCommendString = $"INSERT INTO Facility VALUES ({facility.Facility_id},'{facility.Facility_name}')";
            Console.WriteLine(insertCommendString);
            SqlCommand command = new SqlCommand(insertCommendString, connection);
            Console.WriteLine($"Create Facility:{facility.Facility_id}");
            var numberOfRowsAffected = command.ExecuteNonQuery();
            Console.WriteLine(numberOfRowsAffected);
            return numberOfRowsAffected;
        }

        
        private int DeleteFacility(SqlConnection connection, int Facility_id) 
        {
            Console.WriteLine("Delete Facility");
            string deleteCommandString = $"Delete FROM Facility where Facility_id = {Facility_id} ";
            Console.WriteLine(deleteCommandString);
            SqlCommand command = new SqlCommand(deleteCommandString, connection);
            Console.WriteLine($"Delete Facility :{Facility_id}");
            int numberOfRowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"Number of rows Affected:{numberOfRowsAffected}");
            return numberOfRowsAffected;
        }



        private int UpdateFacility(SqlConnection connection, Facility facility) {
            Console.WriteLine("Update a Facility");
            string updateCommendString = $"UPDATE Facility SET Facility_name='{facility.Facility_name}' where Facility_id = {facility.Facility_id}";
            Console.WriteLine(updateCommendString);
            SqlCommand command = new SqlCommand(updateCommendString, connection);
            Console.WriteLine($"Update Facility : {facility.Facility_id}");
            int numberOfRowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"Number of rows Affected:{numberOfRowsAffected}");
            return numberOfRowsAffected;
        }

        private List<Facility> ListAllFacility(SqlConnection connection) {

            string queryStringAllFacility = "SELECT * FROM Facility";
            Console.WriteLine(queryStringAllFacility);
            SqlCommand query = new SqlCommand(queryStringAllFacility, connection);
            SqlDataReader reader = query.ExecuteReader();
            Console.WriteLine("List Alle Facilites");
            if (!reader.Read())
            {
                Console.WriteLine("No Facility in database");
                reader.Close();
                return null;
            }
            List<Facility> facilities = new List<Facility>();
            while (reader.Read())
            {
                Facility nextFacility = new Facility()
                {
                    Facility_id = reader.GetInt32(0),
                    Facility_name = reader.GetString(1)
                };
                facilities.Add(nextFacility);
                Console.WriteLine(nextFacility);
            }
            reader.Close();
            Console.WriteLine();
            return facilities;
        }
        
        private Facility GetFacility(SqlConnection connection, int Facility_id) 
        {
            string queryStringFacility = $"Select * from Facility where Facility_id={Facility_id}";
            Console.WriteLine(queryStringFacility);
            SqlCommand query = new SqlCommand(queryStringFacility, connection); 
            SqlDataReader reader = query.ExecuteReader();

            Console.WriteLine(Facility_id);

            if (!reader.HasRows)
            {
                Console.WriteLine("No Facility in database");
                reader.Close ();
                return null;
            }
            Facility facility = null;

            if (reader.Read())
            {
                facility = new Facility()
                {
                   Facility_id = reader.GetInt32(0) ,
                   Facility_name = reader.GetString(1)                    
                };
                Console.WriteLine(facility);
            }
            reader.Close();
            Console.WriteLine();
            return facility;

        }
             

        private int GetMaxHotelFacility(SqlConnection connection) {
            string queryStringAlleHotelFacility = "SELECT * FROM HotelFacility";
            Console.WriteLine(queryStringAlleHotelFacility);
            SqlCommand command = new SqlCommand(queryStringAlleHotelFacility, connection);
            SqlDataReader reader = command.ExecuteReader();
            int HotelFacility = 0;
            while (reader.Read())
            {
                HotelFacility = reader.GetInt32(0);
            }
            reader.Close();
            Console.WriteLine($"All Hotel with Facility :{HotelFacility}");
            return HotelFacility;
        }


        private int CreateHotelFacility(SqlConnection connection, HotelFacility hotelFacility) {
            Console.WriteLine("Create Facility");
            string insertCommendHotelFacility = $"INSERT INTO HotelFacility VALUES({hotelFacility.id},{hotelFacility.Hotel_No},{hotelFacility.Facility_id})";
            Console.WriteLine(insertCommendHotelFacility);
            SqlCommand command = new SqlCommand(insertCommendHotelFacility, connection);
            Console.WriteLine($"Create HotelFacility:{hotelFacility.id}");
            
            int numberOfRowsAffected = command.ExecuteNonQuery();
            Console.WriteLine(numberOfRowsAffected);
            return numberOfRowsAffected;
        }

        private int DeleteHotelFacility(SqlConnection connection, int id) 
        {
            Console.WriteLine("Delete HotelFacility");
            string deleteCommandString = $"Delete from HotelFacility where id = {id}";
            Console.WriteLine(deleteCommandString);
            SqlCommand command = new SqlCommand(deleteCommandString, connection);
            Console.WriteLine($"Delete HotelFacility :{id}");
            int numberOfRowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"Number of rows Affected:{numberOfRowsAffected}");
            return numberOfRowsAffected;
        }

        
        private int UpdateHotelFacility(SqlConnection connection, HotelFacility hotelFacility) {
            Console.WriteLine("Update a Facility");
            string updateCommendString = $"UPDATE HotelFacility SET Hotel_No ={hotelFacility.Hotel_No},Facility_id ={hotelFacility.Facility_id} where id ={hotelFacility.id}";
            Console.WriteLine(updateCommendString);
            SqlCommand command = new SqlCommand(updateCommendString, connection);
            Console.WriteLine($"Update Facility :{hotelFacility.id}");
            int numberOfRowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"Number of rows Affected:{numberOfRowsAffected}");
            return numberOfRowsAffected;
        }
        private List<HotelFacility> ListHotelFacility(SqlConnection connection) 
        {

            string queryStringHotelFacility = "Select * from HotelFacility";
            Console.WriteLine(queryStringHotelFacility);
            SqlCommand query = new SqlCommand(queryStringHotelFacility, connection);
            SqlDataReader reader = query.ExecuteReader();
            Console.WriteLine("List Alle HotelFacilites");
            if (!reader.Read())
            {
                Console.WriteLine("No HotelFacility in database");
                reader.Close();
                return null;
            }
            List<HotelFacility> hotelfacility = new List<HotelFacility>();
            while (reader.Read())
            {
                HotelFacility HF = new HotelFacility()
                {
                    id= reader.GetInt32(0),
                    Facility_id = reader.GetInt32(1),
                    Hotel_No = reader.GetInt32(2)

                };
                hotelfacility.Add(HF);
                Console.WriteLine(HF);
            }
            reader.Close();
            Console.WriteLine();
            return hotelfacility;
        }

        private HotelFacility GetHotelFacility(SqlConnection connection, int id) {
            string queryStringHotelFacility = $"SELECT  * from HotelFacility where id ={id}";
            Console.WriteLine(queryStringHotelFacility);
            SqlCommand query = new SqlCommand(queryStringHotelFacility, connection);
            SqlDataReader reader = query.ExecuteReader();

            Console.WriteLine($"{id}");

            if (!reader.HasRows)
            {
                Console.WriteLine("No HotelFacility in database");
                reader.Close();
                return null;
            }
            HotelFacility hotelFacility = null;

            while(reader.Read())
            {
                hotelFacility = new HotelFacility()
                {
                    id= reader.GetInt32(0),
                    Facility_id = reader.GetInt32(1),
                    Hotel_No = reader.GetInt32(2)
                };
                Console.WriteLine(hotelFacility);
            }
            reader.Close();
            Console.WriteLine();
            return hotelFacility;

        }

        public void Start() 
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                ListAllHotel(connection);
                Hotel NewHotel = new Hotel()
                {
                    Hotel_No = GetMaxHotelId(connection),
                    Name = "(New Hotel)",
                    Address = "(New Address)"
                };

                ListAllFacility(connection);
                Facility NewFacility = new Facility()
                {
                    Facility_id = GetMaxFacilityId (connection) +1,
                    Facility_name = "Fodbold"
                };

                CreateFacility(connection, NewFacility);


                ListAllFacility(connection);

                Facility facilityToBeUpdate= GetFacility(connection, NewFacility.Facility_id);
                facilityToBeUpdate.Facility_name = "(diskotek)";


                UpdateFacility(connection, facilityToBeUpdate);

                ListAllFacility(connection);
                 Facility facilityToDelete= GetFacility(connection,facilityToBeUpdate.Facility_id);

                DeleteFacility(connection, facilityToDelete.Facility_id= 9);
               
                ListAllFacility(connection);


                Console.WriteLine();

                ListHotelFacility(connection);


                HotelFacility NewHotelFacility = new HotelFacility()
                {
                    id = GetMaxHotelFacility(connection)+1,
                    Facility_id = GetMaxFacilityId(connection),
                    Hotel_No = GetMaxHotelId (connection)
                };

                CreateHotelFacility(connection,NewHotelFacility) ; 
                

                ListHotelFacility(connection);


                HotelFacility hotelFacilityToBeUpdate = GetHotelFacility(connection, NewHotelFacility.id);
                hotelFacilityToBeUpdate.Facility_id += facilityToBeUpdate.Facility_id  ;
                hotelFacilityToBeUpdate.Hotel_No += GetMaxHotelId(connection) ;

                UpdateHotelFacility(connection, NewHotelFacility);

                ListHotelFacility(connection);

               HotelFacility hotelFacilityToBeDelete= GetHotelFacility(connection, NewHotelFacility.id);
               
                
                DeleteHotelFacility(connection, hotelFacilityToBeDelete.id = 22);

               ListHotelFacility (connection);
            }
        }


    }
}
   