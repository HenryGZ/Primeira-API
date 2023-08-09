using Primeira_API.Model;

namespace Primeira_API.Infraestrutura
{
    public class Employeerepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Employee employee)//adiciona um novo funcionário
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> Get()//retorna uma lista de funcionários
        {
            return _context.Employees.ToList();
        }

        public Employee? Get(int id)//retorna um funcionário
        {
            return _context.Employees.Find(id);
        }
    }
}
