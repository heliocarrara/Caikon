using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Caikon.Models.FormViewModel
{
    public class VMFormPessoa
    {
        public int? PessoaUID { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Senha { get; set; }

        public VMFormPessoa()
        {
        }

        public VMFormPessoa(int? pessoaUID, string nome, string cpf, DateTime dataNascimento, string email, string cep, string senha)
        {
            PessoaUID = pessoaUID;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            Cep = cep;
            Senha = senha;
        }
    }
}
