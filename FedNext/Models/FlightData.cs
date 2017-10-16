/* 
 * Name/Group: Matthew Ruben Group 5
 * Program/Poject: FedNext
 * Description: The Flight data that is needed to create a flight object
 * Data: 10/4/2017
 * Class: CS 270-01
 * Instructor: Dan Masterson
 */
using System;

namespace FedNext
{
    class FlightData
    {
        //Member Properties
        public String FlightCompany { get; set; }
        public int FlightNumber { get; set; }
        public String FlightClass { get; set; }
        public int PlaneCapacity { get; set; }
        public String DepartureDate { get; set; }
        public String DepartingAirport { get; set; }
        public String DepartureTime { get; set; }
        public String ArrivalDate { get; set; }
        public String ArrivalAirport { get; set; }
        public String ArrivalTime { get; set; }



        //Constructor
        public FlightData(String carrier, int flightNumber, String planeClass, int capacity, String departureDate, String departingAirport, String departureTime, String arrivalDate, String arrivalAirport, String arrivalTime)
        {
            FlightCompany = carrier;
            FlightNumber = flightNumber;
            FlightClass = planeClass;
            PlaneCapacity = capacity;
            DepartureDate = departureDate;
            DepartingAirport = departingAirport;
            DepartureTime = departureTime;
            ArrivalDate = arrivalDate;
            ArrivalAirport = arrivalAirport;
            ArrivalTime = arrivalTime;

        }
        public override string ToString()
        {
            string returnString = "\nCarrier: " + FlightCompany + "\n" + "Flight Number: " + FlightNumber + "\n" + "Type: " + FlightClass + "\n" +
                "Cargo Capacity: " + PlaneCapacity + "\n" + "Departure Date, Airport, and Time: " + DepartureDate + " " + DepartingAirport + " " + DepartureTime + "\n" +
                "Arriving Date, Airport, and Time: " + ArrivalDate + " " + ArrivalAirport + " " + ArrivalTime + "\n";
                return returnString;
        }
    }
}
