using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Caikon.Models;
using Caikon.Models.FormViewModel;

namespace Caikon.Controllers
{
    public class PessoasController : Controller
    {
        private readonly CaikonContext _context;

        public PessoasController(CaikonContext context)
        {
            _context = context;
        }

        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pessoa.ToListAsync());
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.PessoaUID == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Cadastro()
        {
            return View("Cadastro");
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro(VMFormPessoa model)
        {
            if (!Verificacao(model))
            {
                View("Cadastro", model);
            }

            var p = new Pessoa(model);
            _context.Add(p);

            var login = new Login()
            {
                Acesso = model.Cpf,
                Senha = model.Senha,
                Validade = DateTime.Now.AddYears(1)
            };

            _context.Add(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PessoaUID,Nome,Cpf,DataNascimento,Email,Cep")] Pessoa pessoa)
        {
            if (id != pessoa.PessoaUID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoa.PessoaUID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(m => m.PessoaUID == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.Pessoa.FindAsync(id);
            _context.Pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoa.Any(e => e.PessoaUID == id);
        }

        private bool Verificacao (VMFormPessoa form)
        {
            if (form.PessoaUID.HasValue)
            {
                if (PessoaExists(form.PessoaUID.Value))
                {
                    //Já existe
                    return false;
                }
            }

            if (String.IsNullOrWhiteSpace(form.Nome) || String.IsNullOrWhiteSpace(form.Cep) || String.IsNullOrWhiteSpace(form.Email))
            {
                return false;
            }

            if (form.Cpf.Length != 11)
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(form.Senha))
            {
                return false;
            }

            return true;
        }
    }
}
