using SalesWebMvcT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SalesWebMvcT.Models.Enums;

namespace SalesRecordsTests
{
    public class SalesRecordTest
    {
        [Fact]
        public void SalesRecord_Constructor_SetProperties()
        {
            var saleDate = new DateTime(2024, 1, 1);
            var seller1 = new Seller { Id = 1, Name = "Red Bob" };
            var sale1 = new SalesRecord
            {
                Id = 1,
                Amount = 300.00,
                Date = saleDate,
                Seller = seller1,
                Status = SaleStatus.Billed
            };
            Assert.Equal(1, sale1.Id);
            Assert.Equal(saleDate, sale1.Date);
            Assert.Equal(300.00, sale1.Amount);
            Assert.Equal(seller1, sale1.Seller);
            Assert.Equal(SaleStatus.Billed, sale1.Status);
        }

        [Fact]
        public void SalesRecord_Date_GetDate()
        {
            // Arrange
            var salesRecord = new SalesRecord { Id = 1, Date = new DateTime(2022, 1, 1), Amount = 100.00, Status = SaleStatus.Pending, Seller = new Seller { Id = 1, Name = "Vendedor 1" } };

            // Act
            var date = salesRecord.Date;

            // Assert
            Assert.Equal(new DateTime(2022, 1, 1), date);
        }

        [Fact]
        public void SalesRecord_Amount_GetAmount()
        {
            // Arrange
            var salesRecord = new SalesRecord { Id = 1, Date = new DateTime(2022, 1, 1), Amount = 100.00, Status = SaleStatus.Pending, Seller = new Seller { Id = 1, Name = "Vendedor 1" } };

            // Act
            var amount = salesRecord.Amount;

            // Assert
            Assert.Equal(100.00, amount);
        }

        [Fact]
        public void SalesRecord_Status_GetStatus()
        {
            // Arrange
            var salesRecord = new SalesRecord { Id = 1, Date = new DateTime(2022, 1, 1), Amount = 100.00, Status = SaleStatus.Pending, Seller = new Seller { Id = 1, Name = "Vendedor 1" } };

            // Act
            var status = salesRecord.Status;

            // Assert
            Assert.Equal(SaleStatus.Pending, status);
        }

        [Fact]
        public void SalesRecord_Seller_GetSeller()
        {
            // Arrange
            var seller = new Seller { Id = 1, Name = "Vendedor 1" };
            var salesRecord = new SalesRecord { Id = 1, Date = new DateTime(2022, 1, 1), Amount = 100.00, Status = SaleStatus.Pending, Seller = seller };

            // Act
            var sellerRetornado = salesRecord.Seller;

            // Assert
            Assert.Equal(seller, sellerRetornado);
        }
    }
}
