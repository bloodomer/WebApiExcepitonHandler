﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiExcepitonHandler
{
    public class MyErrorResponse
    {

        public string ErrorMessage { get; set; }
        public string ErrorAction { get; set; }
        public string ErrorController { get; set; }
    }
}