using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleInjectorDI.Services
{
    public class MyService : IMyService
    {
        public string HelloWorld()
        {
            return "Hello World!!!";
        }
    }
}
