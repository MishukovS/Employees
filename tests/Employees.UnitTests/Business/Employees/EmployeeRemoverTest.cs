using Employees.Core.Business.Employees;
using Employees.Core.DomainModels;
using Employees.Core.Interfaces.Business.Empoyees;
using Employees.Core.Interfaces.DatаAccess;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Employees.UnitTests.Business.Employees
{
    [TestFixture]
    public class EmployeeRemoverTest
    {
        private readonly Mock<IBaseRepository<Employee>> _mockRepo;
        private readonly Mock<IEmployeeReader> _mockReader;

        public EmployeeRemoverTest()
        {
            _mockRepo = new Mock<IBaseRepository<Employee>>();
            _mockReader = new Mock<IEmployeeReader>();
        }

        [Test]
        public async Task DeleteAsync_WhenDeleteEmployee_ThenShouldInvokeEmployeeReaderAndRepository()
        {
            // Arrange
            var remover = new EmployeeRemover(_mockRepo.Object, _mockReader.Object);

            // Act
            await remover.DeleteAsync(It.IsAny<int>());

            // Assert
            _mockReader.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _mockRepo.Verify(x => x.DeleteAsync(It.IsAny<Employee>()), Times.Once);

        }

    }
}
