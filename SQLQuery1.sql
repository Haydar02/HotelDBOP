﻿CREATE TABLE DemoHotel( Hotel_No int NOT NULL PRIMARY KEY, Name VARCHAR(30) NOT NULL, Address VARCHAR(50) NOT NULL ); 
CREATE TABLE DemoRoom( Room_No int NOT NULL, Hotel_No int NOT NULL, Types CHAR(1) DEFAULT 'S', Price FLOAT, CONSTRAINT checkType CHECK (Types IN ('D','F','S') OR Types IS NULL), CONSTRAINT checkPrice CHECK (price BETWEEN 0 AND 9999), FOREIGN KEY (Hotel_No) REFERENCES DemoHotel (Hotel_No) ON UPDATE CASCADE ON DELETE NO ACTION, Primary KEY (Room_No, Hotel_No) ); 
CREATE TABLE DemoGuest ( Guest_No int NOT NULL PRIMARY KEY, Name VARCHAR(30) NOT NULL, Address VARCHAR(50) NOT NULL ); 
CREATE TABLE DemoBooking( Booking_id int IDENTITY(1,1) NOT NULL PRIMARY KEY, Hotel_No int NOT NULL, Guest_No int NOT NULL, Date_From DATE NOT NULL, Date_To DATE NOT NULL, Room_No int NOT NULL, FOREIGN KEY(Guest_No) REFERENCES DemoGuest(Guest_No), FOREIGN KEY(Room_No, Hotel_No) REFERENCES DemoRoom(Room_No, Hotel_No) ); 
CREATE TABLE Facilitetes(Facilitet_id int NOT NULL PRIMARY KEY, Facilitet_name VARCHAR(30));
CREATE TABLE HotelFacilitetes(id int NOT NULL PRIMARY KEY, Hotel_No int NOT NULL FOREIGN KEY(Hotel_No) REFERENCES DemoHotel(Hotel_No), Facilitet_id int NOT NULL FOREIGN KEY(Facilitet_id)  REFERENCES Facilitetes(Facilitet_id) );
ALTER TABLE DemoBooking ADD CONSTRAINT incorrect_dates CHECK ((Date_To > Date_From) AND (Date_From <= '2018-04-04'));