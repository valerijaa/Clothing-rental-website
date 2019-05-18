using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentingWebsite.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RentingWebsite.Models
{
    public class Program
    {
        public static DataConnector d = new DataConnector();
        static void Main(string[] args)
        {
            d.execute();
        }
    }
}