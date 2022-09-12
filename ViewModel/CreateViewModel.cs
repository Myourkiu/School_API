using System.ComponentModel.DataAnnotations;

namespace School_API.ViewModel
{
    public class CreateViewModel
    {
        [Required(ErrorMessage ="Insira o nome do aluno!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Insira o sobrenome do aluno!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Insira a idade do aluno")]
        public int Age { get; set; }
    }
}
