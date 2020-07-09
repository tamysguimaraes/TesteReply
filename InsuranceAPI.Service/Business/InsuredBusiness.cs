using InsuranceAPI.DAL;
using InsuranceAPI.Models;
using System.Collections.Generic;

namespace InsuranceAPI.Service.Business
{
    public class InsuredBusiness
    {
        DALInsured dalInsured = new DALInsured();

        public int SaveInsured(Insured insured)
        {
            return dalInsured.SaveInsured(insured);
        }

        public List<Insured> GetInsureds()
        {
            return dalInsured.GetInsureds();
        }

        public Insured GetInsuredById(int idInsured)
        {
            return dalInsured.GetInsuredById(idInsured);
        }
    }
}
