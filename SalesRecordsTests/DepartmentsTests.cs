using Moq;
using SalesWebMvcT.Models;
using System;
using Xunit;

namespace SalesRecordsTests
{
    public class DepartmentTests
    {
        [Fact]
        public void AddSeller_ShouldAddSellerToList()
        {
            // Arrange
            var department = new Department(1, "Sales");
            var seller = new Seller();

            // Act
            department.AddSeller(seller);

            // Assert
            Assert.Contains(seller, department.Sellers);
        }

        [Fact]
        public void RemoveSeller_ShouldRemoveSellerFromList()
        {
            // Arrange
            var department = new Department(1, "Sales");
            var seller = new Seller();
            department.AddSeller(seller);

            // Act
            department.RemoveSeller(seller);

            // Assert
            Assert.DoesNotContain(seller, department.Sellers);
        }

        [Fact]
        public void TotalSales_ShouldReturnSumOfSalesWithinPeriod()
        {
            // Arrange
            var department = new Department(1, "Sales");
            var seller = new Seller();
            department.AddSeller(seller);

            var startDate = new DateTime(2023, 1, 1);
            var endDate = new DateTime(2023, 12, 31);

            seller.AddSales(new SalesRecord { Date = new DateTime(2023, 6, 1), Amount = 100.0 });
            seller.AddSales(new SalesRecord { Date = new DateTime(2023, 7, 1), Amount = 200.0 });
            seller.AddSales(new SalesRecord { Date = new DateTime(2022, 7, 1), Amount = 50.0 });

            // Act
            var totalSales = department.TotalSales(startDate, endDate);

            // Assert
            Assert.Equal(300.0, totalSales);
        }

    }
}