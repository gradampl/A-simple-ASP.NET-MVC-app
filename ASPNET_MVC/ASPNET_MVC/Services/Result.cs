using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_MVC.Services
{
    public class Result<T>
    {
        public T SuccessResult { get; set; }

        public string Error { get; set; }

        public string SuccessMessage { get; set; }
    }
}
