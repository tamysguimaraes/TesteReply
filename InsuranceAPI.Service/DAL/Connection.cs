using System.Configuration;
using System.Data.SqlClient;

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