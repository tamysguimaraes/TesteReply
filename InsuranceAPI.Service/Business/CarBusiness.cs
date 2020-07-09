using InsuranceAPI.DAL;
using InsuranceAPI.Models;
using System.Collections.Generic;

namespace InsuranceAPI.Service.Business
{
    public class CarBusiness
    {
        DALCar dalCar = new DALCar();

        public int SaveCar(Car car)
        {
            return dalCar.SaveCar(car);
        }
        public List<Car> GetCars()
        {
            return dalCar.GetCars();
        }

        public Car GetCarById(int idCar)
        {
            return dalCar.GetCarById(idCar);
        }
    }
}
