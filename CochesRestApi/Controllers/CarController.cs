using Cars.Application.BusinessModels.Models;
using Cars.Application.BusinessModels.Request;
using Cars.Application.BusinessModels.Response;
using Cars.Application.Contracts.Mappers;
using Cars.Application.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace CochesRestApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarServices _carServices;
        private readonly IConfiguration _configuration;
        public CarController(ICarServices carServices, IConfiguration configuration)
        {
            _carServices = carServices;
            _configuration = configuration;

        }

        [HttpPost]
        [Route("AddCar")]
        public async Task<ActionResult> AddCar(CreateCarRequest createCarRequest)
        {
            try
            {
                var ejemplogetConfiguration=_configuration.GetSection("mytest:valorTest");

                var resultEjemplo = ejemplogetConfiguration.Value;

                var result = await _carServices.AddCar(createCarRequest.ToCarModelMapper());

                return Ok(result.ToCarResponseMapper());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        [Route("UpdateCar")]
        public ActionResult UpdateCar(UpdateCarRequest updateCarRequest)
        {
            try
            {
                _carServices.UpdateCar(updateCarRequest.ToCarModelMapper());
                return Ok(new BaseResponse("Actualizado", true));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(ex.Message, false));
            }
        }

        [HttpPut]
        [Route("UpdateCarModel")]
        public ActionResult UpdateCarModel(int id, string nombre)
        {
            try
            {
                var result = _carServices.UpdateCarModel(id, nombre);
                return Ok(result.ToCarResponseMapper());
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(ex.Message, false));
            }
        }

        [HttpGet]
        [Route("GetCar")]
        public ActionResult GetCar(int id)
        {
            try
            {
                var carResponse = _carServices.GetCar(id);

                return Ok(carResponse.ToCarResponseMapper());
            }
            catch (Exception ex)
            {

                return BadRequest(new BaseResponse(ex.Message, false)); 
            }
        }


        [HttpGet]
        [Route("GetAllCar")]
        public async Task<ActionResult> GetAllCar()
        {
            try
            {
                return Ok(await _carServices.GetAllCar());
            }
            catch (Exception ex)
            {

                return BadRequest(new BaseResponse(ex.Message, false));
            }

        }


        [HttpDelete]
        [Route("DeleteCar")]
        public ActionResult DeleteCar(int id)
        {
            try
            {
                return Ok(_carServices.DeleteCar(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(ex.Message, false));
            }
        }
    }
}
