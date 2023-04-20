﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEEM_Domain.Entities.Responses
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }

        public string Description { get; set; }
    }
}
