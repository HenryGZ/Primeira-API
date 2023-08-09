using Microsoft.AspNetCore.Mvc;
using Primeira_API.Model;
using Primeira_API.ViewModel;

namespace Primeira_API.Controllers
{
    [ApiController]//indica que é uma api
    [Route("api/v1/employee")]//indica o caminho da api
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeerepository;//cria uma variável do tipo IEmployeeRepository

        public EmployeeController(IEmployeeRepository employeerepository)//construtor
        {
            _employeerepository = employeerepository ?? throw new ArgumentNullException(nameof(employeerepository));//injeção de dependência
        }

        [HttpPost]//indica que é um post
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.name, employeeView.age, null);//cria um novo funcionário //photo = null por enquanto

            _employeerepository.Add(employee);//adiciona o funcionário

            return Ok();
        }

        [HttpGet]//indica que é um get
        public IActionResult Get()
        {
            var employees = _employeerepository.Get();//retorna uma lista de funcionários

            return Ok(employees);
        }
    }
}
