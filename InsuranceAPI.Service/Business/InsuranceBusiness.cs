using InsuranceAPI.DAL;
using InsuranceAPI.Models;
using System.Collections.Generic;

namespace InsuranceAPI.Service.Business
{
    public class InsuranceBusiness
    {
        private const int safetyMargin = 3;
        private const int profit = 5;

        DALInsurance dalInsurance = new DALInsurance();
        public int SaveInsurance(int idCar, int idInsured)
        {
            Insurance insurance = new Insurance();
            CarBusiness carBusiness = new CarBusiness();
            InsuredBusiness insuredBusiness = new InsuredBusiness();

            insurance.car = carBusiness.GetCarById(idCar);
            insurance.insured = insuredBusiness.GetInsuredById(idInsured);
            CalculateInsuranceValue(insurance);
            return dalInsurance.SaveInsurance(insurance);
        }

        public List<Insurance> GetInsurances()
        {
            return dalInsurance.GetInsurances();
        }

        public List<Insurance> GetInsuranceByCpf(string cpf)
        {
            List<Insurance> insurances = new List<Insurance>();
            CarBusiness carBusiness = new CarBusiness();
            InsuredBusiness insuredBusiness = new InsuredBusiness();

            insurances = dalInsurance.GetInsuranceByCpf(cpf);
            foreach (Insurance item in insurances)
            {
                item.car = carBusiness.GetCarById(item.car.idCar);
                item.insured = insuredBusiness.GetInsuredById(item.insured.idInsured);
            }
            return insurances;
        }
        public Insurance CalculateInsuranceValue(Insurance insurance)
        {
            double riskRate, riskPremium, purePrice, tradePremium;
            riskRate = ((insurance.car.carValue * 5) / (2 * insurance.car.carValue));
            riskPremium = (riskRate / 100.00) * insurance.car.carValue;
            purePrice = riskPremium * (1 + (safetyMargin / 100.00));
            tradePremium = (profit / 100.00) * purePrice;
            insurance.InsurancePrice = tradePremium + purePrice;
            return insurance;
        }
    }
}
