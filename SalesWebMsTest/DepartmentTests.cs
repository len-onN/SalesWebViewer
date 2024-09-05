using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesWebMvcT.Models;
using SalesWebMvcT.Models.Enums;
using System;

namespace SalesWebMsTest
{
    [TestClass]
    public class DepartmentTests
    {
        [TestMethod]
        public void Department_Constructor_SetProperties()
        {
            // Arrange
            var department = new Department { Id = 1, Name = "Departamento 1" };

            // Act

            // Assert
            Assert.AreEqual(1, department.Id);
            Assert.AreEqual("Departamento 1", department.Name);
        }

        [TestMethod]
        public void Department_AddSeller_AddsSellerToDepartment()
        {
            // Arrange
            var department = new Department { Id = 1, Name = "Departamento 1" };
            var seller = new Seller { Id = 1, Name = "Vendedor 1" };

            // Act
            department.AddSeller(seller);

            // Assert
            Assert.IsTrue(department.Sellers.Contains(seller));
        }

        [TestMethod]
        public void Department_RemoveSeller_RemovesSellerFromDepartment()
        {
            // Arrange
            var department = new Department { Id = 1, Name = "Departamento 1" };
            var seller = new Seller { Id = 1, Name = "Vendedor 1" };

            // Act
            department.AddSeller(seller);
            department.RemoveSeller(seller);

            // Assert
            Assert.IsFalse(department.Sellers.Contains(seller));
        }

        [TestMethod]
        public void Department_TotalSales_ReturnsTotalSales()
        {
            // Arrange
            var department = new Department { Id = 1, Name = "Departamento 1" };
            var seller = new Seller { Id = 1, Name = "Vendedor 1" };
            var salesRecord = new SalesRecord { Id = 1, Date = new DateTime(2022, 1, 1), Amount = 100.00, Status = SaleStatus.Pending, Seller = seller };

            // Act
            seller.AddSales(salesRecord);
            department.AddSeller(seller);

            // Assert
            Assert.AreEqual(100.00, department.TotalSales(new DateTime(2022, 1, 1), new DateTime(2022, 1, 1)));
        }
    }
}
