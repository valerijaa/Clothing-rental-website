using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentingWebsite.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RentingWebsite.Models
{
    public class DataConnector
    {
        public string connectionString =
            "Data Source=cloud5.database.windows.net;Initial Catalog=RentingWebsite;Persist Security Info=True;User ID=Inter2;Password=***********;MultipleActiveResultSets=True;Application Name=EntityFramework";
        public SqlConnection connection;
        public SqlCommand command;

        public DataConnector()
        {
            connection = new SqlConnection(connectionString);
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Article (ImageArticle) VALUES ('~/Content/Images/T66519001_050_suit.jpg')";
            command.CommandType = System.Data.CommandType.Text;
         }

        public void execute ()
        {
            using (connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}