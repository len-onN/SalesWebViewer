using SalesWebMvcT.Models;
using SalesWebMvcT.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SalesRecordsTests
{
    public class SellerTests
    {
        private Department CriarDepartamento()
        {
            return new Department
            {
                Id = 1,
                Name = "Departamento 1"
            };
        }

        private Seller CriarVendedorComDepartamento(Department departamento)
        {
            return new Seller
            {
                Id = 1,
                Name = "Vendedor 1",
                Email = "vendedor1@email.com",
                BirthDate = new DateTime(1990, 1, 1),
                BaseSalary = 1000.00,
                Department = departamento,
                DepartmentId = 1,
                Sales = new List<SalesRecord>()
            };
        }

        private Seller CriarVendedorComDepartamentoESalesRecord(Department departamento, SalesRecord salesRecord)
        {
            return new Seller
            {
                Id = 1,
                Name = "Vendedor 1",
                Email = "vendedor1@email.com",
                BirthDate = new DateTime(1990, 1, 1),
                BaseSalary = 1000.00,
                Department = departamento,
                DepartmentId = 1,
                Sales = new List<SalesRecord> { salesRecord }
            };
        }

        private SalesRecord CriarSalesRecordComVendedor(Seller vendedor)
        {
            return new SalesRecord
            {
                Id = 1,
                Date = new DateTime(2022, 1, 1),
                Amount = 100.00,
                Status = SaleStatus.Pending,
                Seller = vendedor
            };
        }

        [Fact]
        public void Seller_Constructor_SetProperties()
        {
            // Arrange
            var departamento = CriarDepartamento();
            var salesRecord = CriarSalesRecordComVendedor(CriarVendedorComDepartamentoESalesRecord(departamento, CriarSalesRecordComVendedor(CriarVendedorComDepartamento(departamento))));
            var vendedor = CriarVendedorComDepartamentoESalesRecord(departamento, salesRecord);

            // Act

            // Assert
            Assert.Equal(1, vendedor.Id);
            Assert.Equal("Vendedor 1", vendedor.Name);
            Assert.Equal("vendedor1@email.com", vendedor.Email);
            Assert.Equal(new DateTime(1990, 1, 1), vendedor.BirthDate);
            Assert.Equal(1000.00, vendedor.BaseSalary);
            Assert.Equal(departamento, vendedor.Department);
            Assert.Equal(1, vendedor.DepartmentId);
            Assert.Contains(salesRecord, vendedor.Sales);
        }

        [Fact]
        public void Seller_Date_GetBirthDate()
        {
            // Arrange
            var vendedor = CriarVendedorComDepartamento(CriarDepartamento());

            // Act
            var birthDate = vendedor.BirthDate;

            // Assert
            Assert.Equal(new DateTime(1990, 1, 1), birthDate);
        }

        [Fact]
        public void Seller_BaseSalary_GetBaseSalary()
        {
            // Arrange
            var vendedor = CriarVendedorComDepartamento(CriarDepartamento());

            // Act
            var baseSalary = vendedor.BaseSalary;

            // Assert
            Assert.Equal(1000.00, baseSalary);
        }

        [Fact]
        public void Seller_Department_GetDepartment()
        {
            // Arrange
            var departamento = CriarDepartamento();
            var vendedor = CriarVendedorComDepartamento(departamento);

            // Act
            var departmentRetornado = vendedor.Department;

            // Assert
            Assert.Equal(departamento, departmentRetornado);
        }

        [Fact]
        public void Seller_DepartmentId_GetDepartmentId()
        {
            // Arrange
            var departamento = CriarDepartamento();
            var vendedor = CriarVendedorComDepartamento(departamento);

            // Act
            var departmentId = vendedor.DepartmentId;

            // Assert
            Assert.Equal(1, departmentId);
        }

        [Fact]
        public void Seller_Sales_GetSales()
        {
            // Arrange
            var salesRecord = CriarSalesRecordComVendedor(CriarVendedorComDepartamento(CriarDepartamento()));
            var vendedor = CriarVendedorComDepartamentoESalesRecord(CriarDepartamento(), salesRecord);

            // Act
            var sales = vendedor.Sales;

            // Assert
            Assert.Contains(salesRecord, sales);
        }
    }
}