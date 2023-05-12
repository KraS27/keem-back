using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Domain.Entities
{
    public enum StatusCode
    {
        Ok = 200,
        BadRequest = 400,
        NotFound = 404,
        ServerError = 500,
    }
}
