using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro.Services
{
    public class ScopedService: IScopedService
    {
        public string GetData()
        {
            return $"This is from { GetType().Name }";
        }
    }
    public interface IScopedService
    {
        string GetData();
    }
}
