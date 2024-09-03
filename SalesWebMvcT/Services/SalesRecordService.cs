using SalesWebMvcT.Data;
using SalesWebMvcT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvcT.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMvcTContext _context;
        public SalesRecordService(SalesWebMvcTContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(sale => sale.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(sale => sale.Date <= maxDate.Value);
            }
            return await result
                .Include(sale => sale.Seller)
                .Include(sale => sale.Seller.Department)
                .OrderByDescending(sale => sale.Date)
                .ToListAsync();
        }
        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(sale => sale.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(sale => sale.Date <= maxDate.Value);
            }
            return await result
                .Include(sale => sale.Seller)
                .Include(sale => sale.Seller.Department)
                .OrderByDescending(sale => sale.Date)
                .GroupBy(sale => sale.Seller.Department)
                .ToListAsync();
        }
    }
}
