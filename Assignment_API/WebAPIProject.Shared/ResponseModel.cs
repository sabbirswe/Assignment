﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIProject.Shared
{
    public class ResponseMessage<T> 
    {
        public int Total { get; set; }
        public T Result { get; set; }
  
    }
}
