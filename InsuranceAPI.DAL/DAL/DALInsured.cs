using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InsuranceAPI.Models;

namespace InsuranceAPI.DAL
{
    public class DALInsured : Connection
    {
        public int SaveInsured(Insured insured)
        {
            Connection cnn = new Connection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn.connectionStr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [dbo].[Segurado]
                                    VALUES
                                    (@nomeSegurado,@cpf,@idade);
                                    SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@nomeSegurado", insured.Name);
                cmd.Parameters.AddWithValue("@cpf", insured.Cpf);
                cmd.Parameters.AddWithValue("@idade", insured.Age);

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