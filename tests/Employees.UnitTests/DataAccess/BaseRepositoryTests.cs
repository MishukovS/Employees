using AutoFixture;
using Employees.Core.DomainModels;
using Employees.DataAcсess.EF;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace Employees.UnitTests.DataAccess
{
    [TestFixture]
    public class BaseRepositoryTests
    {
        private readonly Fixture _fixture = new Fixture();
        private ApplicationDbContext _dbContext;
        private BaseRepository<Employee> _repository;

        [SetUp]
        public void SetUp()
        {
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "TestEmployees")
              .Options;

            _dbContext = new ApplicationDbContext(dbOptions);
            _dbContext.Database.EnsureDeleted();
            _repository = new BaseRepository<Employee>(_dbContext);
        }

        [Test]
        public void AddAsync_AddOneEmployee_TotalCountShouldBeOne()
        {
            var employee = _fixture.Create<Employee>();

            var spec = new EmployeeSpecification();
            var result = _repository.GetBySpecificationAsync(spec).Result;
            result.Should().HaveCount(0);

            _repository.AddAsync(employee).Wait();
            result = _repository.GetBySpecificationAsync(spec).Result;


            result.Should().HaveCount(1);
        }

        [Test]
        public void AddAsync_AddOneEmployee_GottenEmployeEqualAdded()
        {
            var employee = _fixture.Create<Employee>();
            var spec = new EmployeeSpecification();

            _repository.AddAsync(employee).Wait();
            var result = _repository.GetBySpecificationAsync(spec).Result;


            result.First().Should().BeEquivalentTo(employee, options =>
                     options.Excluding(o => o.Id));
        }

        [Test]
        public void DeleteAsync_AddandDeleteEmployee_TotalCountShouldBeZero()
        {
            var employee = _fixture.Create<Employee>();
            _repository.AddAsync(employee).Wait();

            var spec = new EmployeeSpecification();
            var result = _repository.GetBySpecificationAsync(spec).Result;
            result.Should().HaveCount(1);

            _repository.DeleteAsync(result.First()).Wait();
            result = _repository.GetBySpecificationAsync(spec).Result;

            result.Should().HaveCount(0);
        }

        [Test]
        public void UpdateAsync_UpdateSalarySum_SalarySumIsUpdated()
        {
            var employee = _fixture.Create<Employee>();
            _repository.AddAsync(employee).Wait();

            employee.SalarySum = 50000;
            _repository.UpdateAsync(employee).Wait();

            var spec = new EmployeeSpecification();
            var result = _repository.GetBySpecificationAsync(spec).Result;
            result.First().Should().BeEquivalentTo(employee, options =>
                     options.Excluding(o => o.Id));

        }        
    }
}

