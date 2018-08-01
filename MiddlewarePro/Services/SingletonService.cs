using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro.Services
{
    public class SingletonService: ISingletonService
    {
        public string GetData()
        {
            return $"This is from { GetType().Name }";
        }
    }

    public interface ISingletonService
    {
        string GetData();
    }
}
