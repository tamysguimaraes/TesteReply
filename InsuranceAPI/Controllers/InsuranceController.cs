using InsuranceAPI.Models;
using InsuranceAPI.Service.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsuranceAPI.Controllers
{
    public class InsuranceController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                InsuranceBusiness Insurancebusiness = new InsuranceBusiness();

                List<Insurance> listInsurances = Insurancebusiness.GetInsurances();
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(listInsurances));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        [HttpPost]
        public HttpResponseMessage SaveInsurance(int idCar, int IdInsured)
        {
            try
            {
                InsuranceBusiness Insurancebusiness = new InsuranceBusiness();
                int idInsurance = Insurancebusiness.SaveInsurance(idCar, IdInsured);

                return Request.CreateResponse(HttpStatusCode.OK, "Veículo" + idInsurance + "adicionado");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        [HttpGet]
        public HttpResponseMessage GetInsuranceByCpf(string cpf)
        {
            try
            {
                InsuranceBusiness Insurancebusiness = new InsuranceBusiness();

                List<Insurance> listInsurances = Insurancebusiness.GetInsuranceByCpf(cpf);
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(listInsurances));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
    }
}
