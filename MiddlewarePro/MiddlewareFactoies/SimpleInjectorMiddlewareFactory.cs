using Microsoft.AspNetCore.Http;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro.MiddlewareFactoies
{
    public class SimpleInjectorMiddlewareFactory: IMiddlewareFactory
    {
        private readonly Container _container;
        public SimpleInjectorMiddlewareFactory(Container container)
        {
            _container = container;
        }

        public IMiddleware Create(Type middlewareType)
        {
            return _container.GetInstance(middlewareType) as IMiddleware;
        }

        public void Release(IMiddleware middleware)
        {

        }
    }
}
