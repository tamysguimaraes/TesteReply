using InsuranceAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace InsuranceAPI.DAL
{
    public class DALInsurance : Connection
    {
        Connection cnn = new Connection();
        public int SaveInsurance(Insurance insurance)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn.connectionStr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO [dbo].[Seguro]
                                    VALUES
                                    (idVeiculo=@idVeiculo,
                                    idSegurado=@idSegurado,
                                    TaxaRisco=@TaxaRisco,
                                    PremioRisco=@PremioRisco,
                                    PremioPuro=@PremioPuro,
                                    PremioComercial=@PremioComercial)
                                    SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("@idVeiculo", insurance.car.idCar);
                cmd.Parameters.AddWithValue("@idSegurado", insurance.insured.idInsured);
                cmd.Parameters.AddWithValue("@TaxaRisco", insurance.riskRate);
                cmd.Parameters.AddWithValue("@PremioRisco", insurance.riskPrize);
                cmd.Parameters.AddWithValue("@PremioPuro", insurance.purePrize);
                cmd.Parameters.AddWithValue("@PremioComercial", insurance.commercialPrize);

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

        public List<Insurance> GetInsurances()
        {
            List<Insurance> Insurances = new List<Insurance>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn.connectionStr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT * FROM [dbo].[Seguro]";
                cnn.ConnOpen();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        Insurance retorno = new Insurance();
                        retorno.idInsurance = Convert.ToInt32(dt.Rows[j]["idSeguro"].ToString());
                        retorno.car.idCar = Convert.ToInt32(dt.Rows[j]["idVeiculo"].ToString());
                        retorno.insured.idInsured = Convert.ToInt32(dt.Rows[j]["idSegurado"].ToString());
                        retorno.riskRate = Convert.ToDouble(dt.Rows[j]["TaxaRisco"].ToString());
                        retorno.riskPrize = Convert.ToDouble(dt.Rows[j]["PremioRisco"].ToString());
                        retorno.purePrize = Convert.ToDouble(dt.Rows[j]["PremioPuro"].ToString());
                        retorno.commercialPrize = Convert.ToDouble(dt.Rows[j]["PremioComercial"].ToString());
                        Insurances.Add(retorno);
                    }
                }
                cnn.ConnClose();

                return Insurances;
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

        public List<Insurance> GetInsuranceByCpf(string cpf)
        {
            List<Insurance> Insurances = new List<Insurance>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn.connectionStr;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select
                                    seg.*
                                    from Seguro seg
                                    inner join Segurado segu on seg.idSegurado=segu.idSegurado
                                    where segu.cpf=@cpf";
                cmd.Parameters.AddWithValue("@cpf", cpf);

                cnn.ConnOpen();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        Insurance retorno = new Insurance();
                        retorno.idInsurance = Convert.ToInt32(dt.Rows[j]["idSeguro"].ToString());
                        retorno.car.idCar = Convert.ToInt32(dt.Rows[j]["idVeiculo"].ToString());
                        retorno.insured.idInsured = Convert.ToInt32(dt.Rows[j]["idSegurado"].ToString());
                        retorno.riskRate = Convert.ToDouble(dt.Rows[j]["TaxaRisco"].ToString());
                        retorno.riskPrize = Convert.ToDouble(dt.Rows[j]["PremioRisco"].ToString());
                        retorno.purePrize = Convert.ToDouble(dt.Rows[j]["PremioPuro"].ToString());
                        retorno.commercialPrize = Convert.ToDouble(dt.Rows[j]["PremioComercial"].ToString());
                        Insurances.Add(retorno);
                    }
                }
                cnn.ConnClose();

                return Insurances;
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