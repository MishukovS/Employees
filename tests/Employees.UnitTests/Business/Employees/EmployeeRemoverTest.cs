using Employees.Core.Business.Employees;
using Employees.Core.Interfaces.DatаAccess;
using Employees.Core.DomainModels;
using Moq;
using NUnit.Framework;
using Employees.Core.Interfaces.Business.Empoyees;

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
        public void DeleteAsync_ShouldInvokeEmployeeReaderAndRepository()
        {
            var remover = new EmployeeRemover(_mockRepo.Object, _mockReader.Object);
            remover.DeleteAsync(It.IsAny<int>()).Wait();

            _mockReader.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _mockRepo.Verify(x => x.DeleteAsync(It.IsAny<Employee>()), Times.Once);

        }


    }
}
