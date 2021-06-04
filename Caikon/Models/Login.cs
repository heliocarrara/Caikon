using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Caikon.Models
{
    public class Login
    {
        [Key]
        public int LoginUID { get; set; }
        public string Acesso { get; set; }
        public string Senha { get; set; }
        public DateTime Validade { get; set; }

        public Login()
        {
        }

        public Login(int loginUID, string acesso, string senha, DateTime validade)
        {
            LoginUID = loginUID;
            Acesso = acesso;
            Senha = senha;
            Validade = validade;
        }
    }
}
