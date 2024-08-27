using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvcT.Models;
using SalesWebMvcT.Models.Enums;

namespace SalesWebMvcT.Data
{
    public class SeedingService
    {
        private SalesWebMvcTContext _context;
        public SeedingService(SalesWebMvcTContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return;
            }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Electronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Seller s1 = new Seller(1, "Ming Al", "mingal@gmail.com", new DateTime(1984, 2, 1), 7900.0, d1);
            Seller s2 = new Seller(2, "Alde Baran", "aldebaran@gmail.com", new DateTime(1983, 4, 10), 9000.0, d1);
            Seller s3 = new Seller(3, "Jogui Ster", "joguister@gmail.com", new DateTime(1994, 2, 1), 4400.0, d2);
            Seller s4 = new Seller(4, "Red Bob", "redbob@gmail.com", new DateTime(1995, 1, 29), 4900.0, d2);
            Seller s5 = new Seller(5, "Black Swain", "blackswain@gmail.com", new DateTime(1990, 11, 20), 6300.0, d3);
            Seller s6 = new Seller(6, "Gold Rogerio", "goldrogerio@gmail.com", new DateTime(1889, 12, 25), 5850.40, d3);
            Seller s7 = new Seller(7, "Mingali Na", "mingalina@gmail.com", new DateTime(1984, 4, 14), 7500.0, d4);
            Seller s8 = new Seller(8, "Ding Al", "dingal@gmail.com", new DateTime(1981, 12, 12), 9200.0, d4);

            SalesRecord sl1 = new SalesRecord(1, new DateTime(2024, 12, 31), 2034.32, SaleStatus.Billed, s1);
            SalesRecord sl2 = new SalesRecord(2, new DateTime(2024, 12, 21), 3236.82, SaleStatus.Billed, s2);
            SalesRecord sl3 = new SalesRecord(3, new DateTime(2024, 12, 16), 2836.58, SaleStatus.Billed, s3);
            SalesRecord sl4 = new SalesRecord(4, new DateTime(2024, 12, 11), 1953.61, SaleStatus.Canceled, s4);
            SalesRecord sl5 = new SalesRecord(5, new DateTime(2024, 12, 31), 2034.32, SaleStatus.Billed, s5);
            SalesRecord sl6 = new SalesRecord(6, new DateTime(2024, 12, 31), 5004.10, SaleStatus.Pending, s6);
            SalesRecord sl7 = new SalesRecord(7, new DateTime(2024, 12, 30), 136.82, SaleStatus.Billed, s7);
            SalesRecord sl8 = new SalesRecord(8, new DateTime(2024, 12, 15), 200.50, SaleStatus.Billed, s8);
            SalesRecord sl9 = new SalesRecord(9, new DateTime(2024, 11, 30), 3033.52, SaleStatus.Billed, s1);
            SalesRecord sl10 = new SalesRecord(10, new DateTime(2024, 11, 21), 3436.86, SaleStatus.Billed, s2);
            SalesRecord sl11 = new SalesRecord(11, new DateTime(2024, 11, 16), 3835.38, SaleStatus.Billed, s3);
            SalesRecord sl12 = new SalesRecord(12, new DateTime(2024, 11, 11), 2955.63, SaleStatus.Canceled, s4);
            SalesRecord sl13 = new SalesRecord(13, new DateTime(2024, 11, 30), 2635.42, SaleStatus.Billed, s5);
            SalesRecord sl14 = new SalesRecord(14, new DateTime(2024, 11, 30), 5505.15, SaleStatus.Billed, s6);
            SalesRecord sl15 = new SalesRecord(15, new DateTime(2024, 11, 29), 5516.85, SaleStatus.Billed, s7);
            SalesRecord sl16 = new SalesRecord(16, new DateTime(2024, 11, 14), 20000.50, SaleStatus.Pending, s8);
            SalesRecord sl17 = new SalesRecord(17, new DateTime(2024, 12, 11), 3453.61, SaleStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7, s8);
            _context.SalesRecord.AddRange(
                sl1, sl2, sl3, sl4, sl5, sl6, sl7, sl8,
                sl9, sl10, sl11, sl12, sl13, sl14, sl15, sl16, sl17
            );
            _context.SaveChanges();
        }
    }
}
