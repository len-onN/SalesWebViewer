using SalesWebMvcT.Data;
using SalesWebMvcT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvcT.Services.Exceptions;

namespace SalesWebMvcT.Services
{
    public class SellerService
    {  
        private readonly SalesWebMvcTContext _context;
        
        public SellerService(SalesWebMvcTContext context)
        {
            _context = context;
        }
        
        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException
                    (
                        "Seller has sales. Can't be deleted. <br /> <br />" + e.Message
                    );
            }
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasSeller = await _context.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasSeller)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
