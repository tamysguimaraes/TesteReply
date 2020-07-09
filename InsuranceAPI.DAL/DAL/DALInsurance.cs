using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InsuranceAPI.Models;

namespace InsuranceAPI.DAL
{
    public class DALInsurance : Connection
    {
        public int SaveInsurance(Insurance insurance)
        {
            Connection cnn = new Connection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn.connectionStr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [dbo].[Veiculo]
                                    VALUES
                                    (@valorVeiculo,@marcaModelo);
                                    SELECT SCOPE_IDENTITY();";
                //cmd.Parameters.AddWithValue("@valorVeiculo", insurance.);
                //cmd.Parameters.AddWithValue("@marcaModelo", insurance.Brand);

                cnn.ConnOpen();
                int Id = Convert.ToInt32(cmd.ExecuteScalar());
                return Id;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                cnn.ConnClose();
            }
        }
    }
}