using Microsoft.Extensions.DependencyInjection;
using MVCPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    public interface IExceptionService
    {
        void Save(Exception ex);
    }

    public class ExceptionService : IExceptionService
    {
        private readonly IServiceProvider _serviceProvider;
        public ExceptionService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Save(Exception ex)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<MVCProContext>();
                _context.Add(new Book() { Title = ex.Message });
                _context.SaveChanges();
            }
        }
    }
}
