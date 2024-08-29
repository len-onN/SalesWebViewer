using SalesWebMvcT.Data;
using SalesWebMvcT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvcT.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcTContext _context;
        public DepartmentService(SalesWebMvcTContext context)
        {
            _context = context;
        }
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
