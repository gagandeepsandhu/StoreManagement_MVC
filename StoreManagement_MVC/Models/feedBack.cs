using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace StoreManagement_MVC.Models
{
    public class feedBack
    {
        // database connection with user name or password to validate the user name or password 
        public String Name { get; set; }
        public String Email { get; set; }
       
        public String Message { get; set; }

        //global declaration of the variable 
        SqlConnection connection;
        String connection_String = "Data Source=DESKTOP-17CKR5L;Initial Catalog=Inventory;Integrated Security=True";
        SqlCommand command;
        SqlDataReader Datareader;

        // implemtneting the method of the interface
        //using the concept of oops define a single method that is used to insert delete and update the record in the table 
        public void send(String qry)
        {

            connection = new SqlConnection(connection_String);
            connection.Open();
            command = new SqlCommand(qry, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }



    }
}