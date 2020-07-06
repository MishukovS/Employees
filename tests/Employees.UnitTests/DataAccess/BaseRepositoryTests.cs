using AutoFixture;
using Employees.Core.DomainModels;
using Employees.DataAcсess.EF;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task AddAsync_WhenAddOneEmployee_ThenTotalCountShouldBeOne()
        {
            // Arrange
            var employee = _fixture.Create<Employee>();
            var spec = new EmployeeSpecification();

            // Act
            await _repository.AddAsync(employee);
            var result = await _repository.GetBySpecificationAsync(spec);

            // Assert
            result.Should().HaveCount(1);
        }

        [Test]
        public async Task AddAsync_WhenAddOneEmployee_ThenGottenEmployeEqualAdded()
        {
            // Arrange
            var employee = _fixture.Create<Employee>();
            var spec = new EmployeeSpecification();

            // Act
            await _repository.AddAsync(employee);
            var result = await _repository.GetBySpecificationAsync(spec);

            // Assert
            result.First().Should().BeEquivalentTo(employee, options =>
                     options.Excluding(o => o.Id));
        }

        [Test]
        public async Task DeleteAsync_WhenAddandDeleteEmployee_ThenTotalCountShouldBeZero()
        {
            // Arrange
            var employee = _fixture.Create<Employee>();
            var spec = new EmployeeSpecification();

            // Act
            await _repository.AddAsync(employee);

            var result = await _repository.GetBySpecificationAsync(spec);    

            await _repository.DeleteAsync(result.First());
            result = await _repository.GetBySpecificationAsync(spec);

            // Assert
            result.Should().HaveCount(0);
        }

        [Test]
        public async Task UpdateAsync_WhenUpdateSalarySum_ThenSalarySumIsUpdated()
        {
            // Arrange
            var spec = new EmployeeSpecification();
            var employee = _fixture.Create<Employee>();
            await _repository.AddAsync(employee);

            // Act
            employee.SalarySum = 50000;
            await _repository.UpdateAsync(employee);
            
            var result = await _repository.GetBySpecificationAsync(spec);

            // Assert
            result.First().Should().BeEquivalentTo(employee, options =>
                     options.Excluding(o => o.Id));

        }        
    }
}

