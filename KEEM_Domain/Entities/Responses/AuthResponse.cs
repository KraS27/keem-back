using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Domain.Entities.Responses
{
    public class AuthResponse : BaseResponse<bool>
    {
        public StatusCode StatusCode { get; set; }
    }
}
