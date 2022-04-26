using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Application.BusinessModels.Request
{
    public class UpdateUserRequest: UserRequest
    {
        public int Id { get; set; } 
       
    }
}
