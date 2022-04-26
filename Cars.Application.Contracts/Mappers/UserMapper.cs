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
    public static class UserMapper
    {
        public static UserModel ToUserModelMapper(this CreateUserRequest createUserRequest)
        {
            return new UserModel()
            {
                Name = createUserRequest.Name,
                Email = createUserRequest.Email,
                Password = createUserRequest.Password
            };
        }

        public static CreateUserResponse ToUserResponseMapper(this UserModel userModel)
        {
            return new CreateUserResponse()
            {
                Name = userModel.Name,
                Email = userModel.Email,
                Password = userModel.Password,
                Id = userModel.Id,
                Status = true
            };
        }

        public static UserDto ToUserDtoMapper(this UserModel userModel)
        {
            return new UserDto()
            {
                Email = userModel.Email,
                Name = userModel.Name,
                Password = userModel.Password,
                Id = userModel.Id,
            };
        }

        public static UserModel ToUserModelMapper(this UserDto userDto)
        {
            return new UserModel()
            {
                Email = userDto.Email,
                Name = userDto.Name,
                Password = userDto.Password,
                Id = userDto.Id,
            };
        }

        public static UserModel ToUserModelMapper(this UpdateUserRequest updateUserRequest)
        {
            return new UserModel()
            {
                Email = updateUserRequest.Email,
                Id = updateUserRequest.Id,
                Name = updateUserRequest.Name,
                Password = updateUserRequest.Password
            };
        }


        public static User ToUserMapper(this UserModel userModel)
        {
            return new User()
            {
                Id = userModel.Id,
                Email = userModel.Email,
                Password = userModel.Password,
                Name = userModel.Name
            };


        }

        public static UserModel ToUserModelMapper(this User user)
        {
            return new UserModel()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name
            };
        }
    }
}
