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
    public class CarController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                CarBusiness carbusiness = new CarBusiness();

                List<Car> listCars = carbusiness.GetCars();
                return Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(listCars));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }

        [HttpPost]
        public HttpResponseMessage SaveCar(Car sendCar)
        {
            try
            {
                CarBusiness carbusiness = new CarBusiness();
                int idCar = carbusiness.SaveCar(sendCar);

                return Request.CreateResponse(HttpStatusCode.OK, "Veículo" + idCar + "adicionado");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.ToString());
            }
        }



    }
}
