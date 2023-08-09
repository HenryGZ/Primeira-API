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
        public IActionResult Add([FromForm]EmployeeViewModel employeeView) //indica que o método recebe um formulário
        {

            var filePAth = Path.Combine("Storage", employeeView.Photo.FileName);//cria o caminho do arquivo para salvar uma foto dentro da API

            using Stream fileStream = new FileStream(filePAth, FileMode.Create);//cria um arquivo
            employeeView.Photo.CopyTo(fileStream);//copia a foto para o arquivo

            var employee = new Employee(employeeView.Name, employeeView.Age, filePAth);//cria um novo funcionário //photo = null por enquanto


            _employeerepository.Add(employee);//adiciona o funcionário

            return Ok();
        }

        [HttpPost]//indica que é um post
        [Route("{id}/dowload")]//indica o caminho da api
        public IActionResult DowloadPhoto(int id)
        {
            var employee = _employeerepository.Get(id);//retorna um funcionário
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);//lê o arquivo
            return File(dataBytes, "image/png");//retorna o arquivo
        }

        [HttpGet]//indica que é um get
        public IActionResult Get()
        {
            var employees = _employeerepository.Get();//retorna uma lista de funcionários

            return Ok(employees);
        }
    }
}
