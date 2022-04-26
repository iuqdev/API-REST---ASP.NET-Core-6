using Cars.Application.BusinessModels.Request;
using Cars.Application.BusinessModels.Response;
using Cars.Application.Contracts.Mappers;
using Cars.Application.Contracts.Services;
using Cars.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CochesRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;

        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> AddUser(CreateUserRequest createUserRequest)
        {
            try
            {
                var result= await _userServices.AddUser(createUserRequest.ToUserModelMapper());

                return Ok(result.ToUserResponseMapper());
            }
            catch (Exception ex)
            {
                
                return BadRequest(new CreateUserResponse(ex.Message,false));
            }

        }

        [HttpPut]
        [Route("UpdateUser")]
        public  ActionResult UpdateUser(UpdateUserRequest updateUserRequest)
        {
            try
            {
                 _userServices.UpdateUser(updateUserRequest.ToUserModelMapper());
                 return Ok(new BaseResponse("Insertado", true));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(ex.Message, false));
            }
        }

        [HttpPut]
        [Route("UpdateUserName")]
        public ActionResult UpdateUserName(int id, string nombre)
        {
            try
            {
                var result=_userServices.UpdateUserName(id,nombre);
                return Ok(result.ToUserResponseMapper());
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(ex.Message, false));
            }
        }

        [HttpGet]
        [Route("GetUser")]
        public ActionResult GetUser(int id)
        {
            var userResponse = _userServices.GetUser(id);

            return Ok(userResponse.ToUserResponseMapper());

        }


        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                return Ok(_userServices.DeleteUser(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse(ex.Message, false));
            }
        }

    }


   
}
