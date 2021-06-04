using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Caikon.Models.FormViewModel
{
    public class VMFormLogin
    {
        public string Acesso { get; set; }
        public string Senha { get; set; }

        public VMFormLogin()
        {
        }
    }
}
