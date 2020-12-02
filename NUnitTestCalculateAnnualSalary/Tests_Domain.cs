using Domain.EmployeeAggregate.Interfaces;
using Domain.EmployeeAggregate.Services;
using Infrastructure.Respositories;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests_Domain
    {
        private IEmployeeRepository _employeeRepository;
        private EmployeeService _employeeService;
        [SetUp]
        public void Setup()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri("http://masglobaltestapi.azurewebsites.net/api/");

            EmployeeRepository employeeRepository = new EmployeeRepository(httpClient);
            _employeeRepository = employeeRepository;

            _employeeService = new EmployeeService(_employeeRepository);
        }

        [Test]
        public async Task GetEmployee()
        {
            var result = await _employeeService.EmployeeGet(null);
            Assert.AreEqual(2, result.Count);
        }

        [TestCase(1)]
        [TestCase(2)]
        public async Task GetEmployee_One(int id)
        {
            var result = await _employeeService.EmployeeGet(id);
            Assert.AreEqual(1, result.Count);
        }

        [TestCase(-1)]
        public async Task GetEmployee_None(int id)
        {
            var result = await _employeeService.EmployeeGet(id);
            Assert.AreEqual(0, result.Count);
        }
    }
}