using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCorePro.Data;
using EFCorePro.Extensions;
using EFCorePro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EFCoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EFCoreController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> FromSqlWithSP()
        {
            //var result1 = await _context.Set<TodoItem>().FromSql("execute [dbo].[get_TodoItem]").ToListAsync();
            //var result3 = await _context.Set<ToDoItemVM>().FromSql("execute [dbo].[get_TodoItem]").ToListAsync();

            //var result2 = await _context.Query<ToDoItemVM>().FromSql("execute [dbo].[get_TodoItem]").ToListAsync();
            var result = _context.RawSqlQuery<ToDoItemVM>("execute [dbo].[get_TodoItem]");
            return Ok(result);
        }
    }
}