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
    public class LoginsController : Controller
    {
        private readonly CaikonContext _context;

        public LoginsController(CaikonContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View("Entrar", new VMFormLogin());
        }

        public IActionResult Cadastro()
        {
            return RedirectToAction("Cadastro", "Pessoas");
        }

        // GET: Logins
        public async Task<IActionResult> Entrar(VMFormLogin model)
        {
            try
            {
                var dataAtual = DateTime.Today;

                Login login = await _context.Login.FirstOrDefaultAsync(m => m.Acesso == model.Acesso 
                                                && m.Senha == model.Senha && m.Validade >= dataAtual);

                if (login == null)
                {
                    return View("Entrar", model);
                }
                else
                {
                    var pessoa = await _context.Pessoa
                    .FirstOrDefaultAsync(m => m.Cpf == model.Acesso);

                    if (pessoa != null)
                    {
                        return RedirectToAction("Details", "Pessoas", new { id = pessoa.PessoaUID});
                    }
                }
            }
            catch
            {

            }
            

            return View("Entrar", model);
        }

        /*
        // GET: Logins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.LoginUID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // GET: Logins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoginUID,Acesso,Senha,Validade")] Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        // GET: Logins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        // POST: Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoginUID,Acesso,Senha,Validade")] Login login)
        {
            if (id != login.LoginUID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.LoginUID))
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
            return View(login);
        }

        // GET: Logins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.LoginUID == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var login = await _context.Login.FindAsync(id);
            _context.Login.Remove(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.LoginUID == id);
        }
    }
}
