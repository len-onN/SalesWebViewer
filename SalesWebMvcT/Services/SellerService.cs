using SalesWebMvcT.Data;
using SalesWebMvcT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvcT.Services
{
    public class SellerService
    {  
        private readonly SalesWebMvcTContext _context;
        public SellerService(SalesWebMvcTContext context)
        {
            _context = context;
        }
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
