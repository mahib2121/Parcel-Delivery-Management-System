﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel_Delivery_Management_System
{
    class CompleteOrder
    {
        public string CustName { get; set; }
        public int CustID { get; set; }
        public int OrderID { get; set; }
        public string CustPhoneNo { get; set; }
        public string ApartmentNo { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        
        public int MarkAsComplete()
        {
            
            using (SqlConnection con = new SqlConnection(@"Data Source=Mahib\SQLEXPRESS;Initial Catalog=Final_DataBase 2 (1);Integrated Security=True;Encrypt=False;TrustServerCertificate=True"))
            {
                con.Open();

                
                SqlCommand insertCommand = new SqlCommand("INSERT INTO CompleteOrdersInfo(Cust_Name, Cust_ID, Cust_PhoneNo, Apartment_No, Street_Address, Postal_Code, City, Order_ID)" +
                    " VALUES(@custName, @custID, @custPhoneNo, @apartmentNo, @streetAddress, @postalCode, @city, @orderid)", con);

                insertCommand.Parameters.AddWithValue("@custName", CustName);
                insertCommand.Parameters.AddWithValue("@custID", CustID);
                insertCommand.Parameters.AddWithValue("@custPhoneNo", CustPhoneNo);
                insertCommand.Parameters.AddWithValue("@apartmentNo", ApartmentNo);
                insertCommand.Parameters.AddWithValue("@streetAddress", StreetAddress);
                insertCommand.Parameters.AddWithValue("@postalCode", PostalCode);
                insertCommand.Parameters.AddWithValue("@city", City);
                insertCommand.Parameters.AddWithValue("@orderid", OrderID);

                int rowsAffected = insertCommand.ExecuteNonQuery();

                string deleteQuery = "DELETE FROM TransitOrdersInfo WHERE Order_ID = @orderID";
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, con);
                deleteCommand.Parameters.AddWithValue("@orderID", OrderID);

                rowsAffected += deleteCommand.ExecuteNonQuery();

                return rowsAffected;
            }
        }
    }
}
