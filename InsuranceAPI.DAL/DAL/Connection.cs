using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InsuranceAPI.DAL
{
    public class Connection
    {
        public SqlConnection connectionStr = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public void ConnOpen()
        {
            connectionStr.Open();
        }

        public void ConnClose()
        {
            connectionStr.Close();
        }
    }
}