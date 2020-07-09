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
    public class InsuredController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                InsuredBusiness Insuredbusiness = new InsuredBusiness();

                List<Insured> listInsureds = Insuredbusiness.GetInsureds();
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(listInsureds));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        [HttpPost]
        public HttpResponseMessage SaveInsured(Insured sendInsured)
        {
            try
            {
                InsuredBusiness Insuredbusiness = new InsuredBusiness();
                int idInsured = Insuredbusiness.SaveInsured(sendInsured);

                return Request.CreateResponse(HttpStatusCode.OK, "Veículo" + idInsured + "adicionado");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }
    }
}
