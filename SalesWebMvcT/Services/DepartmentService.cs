using SalesWebMvcT.Data;
using SalesWebMvcT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvcT.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcTContext _context;
        public DepartmentService(SalesWebMvcTContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
