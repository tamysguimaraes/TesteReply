using InsuranceAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InsuranceAPI.DAL
{
    public class DALInsured : Connection
    {
        Connection cnn = new Connection();
        public int SaveInsured(Insured insured)
        {
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

        public List<Insured> GetInsureds()
        {
            List<Insured> insureds = new List<Insured>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn.connectionStr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM [dbo].[Segurado]";
                cnn.ConnOpen();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        Insured retorno = new Insured();
                        retorno.idInsured = Convert.ToInt32(dt.Rows[j]["idSegurado"].ToString());
                        retorno.Cpf = dt.Rows[j]["cpf"].ToString();
                        retorno.Age = Convert.ToInt32(dt.Rows[j]["idade"].ToString());
                        retorno.Name = dt.Rows[j]["nomeSegurado"].ToString();
                        insureds.Add(retorno);
                    }
                }
                cnn.ConnClose();

                return insureds;
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

        public Insured GetInsuredById(int idInsured)
        {
            Insured insured = new Insured();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn.connectionStr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM [dbo].[Segurado] WHERE idSegurado=@idSegurado";
                cmd.Parameters.AddWithValue("@idSegurado", idInsured);

                cnn.ConnOpen();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    insured.idInsured = Convert.ToInt32(dt.Rows[0]["idSegurado"].ToString());
                    insured.Cpf = dt.Rows[0]["cpf"].ToString();
                    insured.Age = Convert.ToInt32(dt.Rows[0]["idade"].ToString());
                    insured.Name = dt.Rows[0]["nomeSegurado"].ToString();
                }
                cnn.ConnClose();

                return insured;
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