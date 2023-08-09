using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Primeira_API.Model
{
    [Table("employee")] //indica o nome da tabela no banco de dados
    public class Employee
    {
        [Key] //indica que o campo é uma chave primária
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string? photo { get; set; }
        
        public Employee(string name, int age, string photo) 
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.age = age;
            this.photo = photo;


        }
    }
}
