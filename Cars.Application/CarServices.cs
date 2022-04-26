using Cars.Application.BusinessModels.Models;
using Cars.Application.BusinessModels.Request;
using Cars.Application.BusinessModels.Response;
using Cars.Application.Contracts.Mappers;
using Cars.Application.Contracts.Services;
using Cars.DataAccess.Contracts.Repositories;

namespace Cars.Application.Services
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepository _carRepository;
        public CarServices (ICarRepository carRepository)
        {
            _carRepository=carRepository;   
        }

        public async Task<CarModel> AddCar(CarModel carModel)
        {
            var result=  await  _carRepository.AddCar(carModel.ToCarDtoMapper());

            return result.ToCarModelMapper();

        }

        public bool DeleteCar(int id)
        {
            _carRepository.Delete(id);
            _carRepository.SaveChanges();
            return true;

        }

        public CarModel GetCar(int id)
        {
            var car = _carRepository.GetByID(id);
            return car.ToCarModelMapper();
        }

        public async Task<List<CarModel>> GetAllCar()
        {
            var car = await _carRepository.GetAsync();
            return car.ToListCarModelMapper();
        }

        public bool UpdateCar(CarModel carModel)
        {
            _carRepository.Update(carModel.ToCarMapper());
            _carRepository.SaveChanges();

            return true; ;
        }

        public CarModel UpdateCarModel(int id, string model)
        {
            var car = _carRepository.GetByID(id);
            car.Model = model;
            _carRepository.Update(car);
            _carRepository.SaveChanges();
            return car.ToCarModelMapper();
        }

       
    }
}