using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace StoreManagement_MVC.Models
{
    public class LoginDetails
    {

        // database connection with user name or password to validate the user name or password 
        public String UserName { get; set; }
        public String UserPassword { get; set; }


        //global declaration of the variable 
        SqlConnection connection;
        String connection_String = "Data Source=DESKTOP-17CKR5L;Initial Catalog=Inventory;Integrated Security=True";
        SqlCommand command;
        SqlDataReader Datareader;


        //this is the user define method that is used for the login of the admin that is help full for the controller class
        public DataTable SrchLogin(String qry)
        {
            DataTable tbl = new DataTable();


            connection = new SqlConnection(connection_String);

            connection.Open();
            command = new SqlCommand(qry, connection);

            Datareader = command.ExecuteReader();

            tbl.Load(Datareader);

            connection.Close();

            return tbl;
        }
    }
}