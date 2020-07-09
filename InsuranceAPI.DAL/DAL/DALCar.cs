using InsuranceAPI.DAL.Mapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InsuranceAPI.DAL
{
    public class DALCar : Connection
    {
        public int SaveCar(CarMapping car)
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
                cmd.Parameters.AddWithValue("@valorVeiculo", car.carValue);
                cmd.Parameters.AddWithValue("@marcaModelo", car.Brand);

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