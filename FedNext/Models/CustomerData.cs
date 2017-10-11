/*
 * Name/Group:  Matthew Ruben Group 5
 * Program/Project: FedNext 
 * Description:The Customer data that is needed to create a customer object
 * Date: 9/18/2017
 * Class: CS 270-01
 * Instrutor: Dan Masterson
 */
using System;


namespace FedNext
{
    class CustomerData
    {

        //Member properties
        public int CustomerId { get; set; }
        public String Name { get; set; }
        public String PhoneNum { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String ZipCode { get; set; }
        public String State { get; set; }



        //constructor
        public CustomerData(int id, String name, String street, String city, String state, String zipCode, String phone)
        {

            CustomerId = id;
            Name = name;
            Street = street;
            City = city;
            ZipCode = zipCode;
            State = state;
            PhoneNum = phone;

        }



        public override string ToString()
        {
            String returnString = "\nName: " + Name + "\n" + "Address: " + Street + " " + City + " " + State +
                                  " " + ZipCode + "\n" + "Contact: " + PhoneNum + "\n";
            return returnString;
        }


    }
}
