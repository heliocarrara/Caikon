using Caikon.Models.FormViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace Caikon.Models
{
    public class Pessoa
    {
        [Key]
        public int PessoaUID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }

        public Pessoa()
        {
        }

        public Pessoa(VMFormPessoa p)
        {
            PessoaUID = 0;
            Nome = p.Nome;
            Cpf = p.Cpf;
            DataNascimento = p.DataNascimento;
            Email = p.Email;
            Cep = p.Cep;
        }
    }
}
