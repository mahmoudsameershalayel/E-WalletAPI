﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.UseCases
{
    public class BaseResponse <T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; } = false;
        public string? Message { get; set; }
    }
}
