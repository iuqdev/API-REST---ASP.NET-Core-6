using Cars.Application.BusinessModels.Models;
using Cars.Application.BusinessModels.Request;
using Cars.Application.BusinessModels.Response;
using Cars.DataAccess.Contracts.Dtos;
using Cars.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.Contracts.Mappers
{
    public static class CarModelMapper
    {
        public static CarDto ToCarDtoMapper(this CarModel carModel)
        {
            return new CarDto()
            {
                Brand= carModel.Brand,  
                Id=carModel.Id,
                Model=carModel.Model,
                Version=carModel.Version
            };
        }


        public static CarModel ToCarModelMapper(this CarDto carDto)
        {
            return new CarModel()
            {
                Brand = carDto.Brand,
                Id = carDto.Id,
                Model = carDto.Model,
                Version = carDto.Version
            };
        }


        public static CarModel ToCarModelMapper(this CreateCarRequest createCarRequest)
        {
            return new CarModel()
            {
                Brand = createCarRequest.Brand,
                Model = createCarRequest.Model,
                Version = createCarRequest.Version
            };
        }


        public static CreateCarResponse ToCarResponseMapper(this CarModel carModel)
        {
            return new CreateCarResponse()
            {
                Id = carModel.Id,
                Brand = carModel.Brand,
                Model = carModel.Model,
                Version = carModel.Version
            };
        }

        public static CarModel ToCarModelMapper(this UpdateCarRequest updateCarRequest)
        {
            return new CarModel()
            {
              Brand= updateCarRequest.Brand,    
              Id=updateCarRequest.Id,   
              Model= updateCarRequest.Model,
              Version= updateCarRequest.Version
            };
        }


        public static Car ToCarMapper(this CarModel carModel)
        {
            return new Car()
            {
                Brand = carModel.Brand,
                Id = carModel.Id,
                Model = carModel.Model,
                Version= carModel.Version   
            };


        }

        public static CarModel ToCarModelMapper(this Car car)
        {
            return new CarModel()
            {
                Brand = car.Brand,
                Id = car.Id,
                Model = car.Model,
                Version = car.Version
            };
        }



        public static List<CarModel> ToListCarModelMapper(this IEnumerable<Car> car)
        {
            List<CarModel> carModels = new List<CarModel>();   
            foreach (var item in car)
            {
                carModels.Add(item.ToCarModelMapper());
            }
            return carModels;
        }

    }
}
