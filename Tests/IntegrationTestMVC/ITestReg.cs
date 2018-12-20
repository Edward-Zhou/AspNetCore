using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTestMVC
{
    public interface ITestReg
    {
        string HelloWorld();
    }
    public class TestReg : ITestReg
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
