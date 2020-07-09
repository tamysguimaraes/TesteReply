using InsuranceAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InsuranceAPI.DAL
{
    public class DALCar : Connection
    {
        Connection cnn = new Connection();
        public int SaveCar(Car car)
        {
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

        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn.connectionStr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM [dbo].[Veiculo]";
                cnn.ConnOpen();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        Car retorno = new Car();
                        retorno.idCar = Convert.ToInt32(dt.Rows[j]["idVeiculo"].ToString());
                        retorno.carValue = Convert.ToDouble(dt.Rows[j]["valorVeiculo"].ToString());
                        retorno.Brand = dt.Rows[j]["marcaModelo"].ToString();
                        cars.Add(retorno);
                    }
                }
                cnn.ConnClose();

                return cars;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cnn.ConnClose();
            }

        }

        public Car GetCarById(int idCar)
        {
            try
            {
                Car car = new Car();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn.connectionStr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM [dbo].[Veiculo] WHERE idVeiculo=@idVeiculo";
                cmd.Parameters.AddWithValue("@idVeiculo", idCar);

                cnn.ConnOpen();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    car.idCar = Convert.ToInt32(dt.Rows[0]["idVeiculo"].ToString());
                    car.carValue = Convert.ToDouble(dt.Rows[0]["valorVeiculo"].ToString());
                    car.Brand = dt.Rows[0]["marcaModelo"].ToString();
                }
                cnn.ConnClose();

                return car;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cnn.ConnClose();
            }
        }
    }
}