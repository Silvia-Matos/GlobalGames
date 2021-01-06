using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlobalGames.Dados;
using GlobalGames.Dados.Entidades;

namespace GlobalGames.Controllers
{
    public class OrcamentoPedidosController : Controller
    {
        private readonly DataContext _context;

        public OrcamentoPedidosController(DataContext context)
        {
            _context = context;
        }

        // GET: OrcamentoPedidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.PedidosOrcamento.ToListAsync());
        }

        // GET: OrcamentoPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamentoPedido = await _context.PedidosOrcamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orcamentoPedido == null)
            {
                return NotFound();
            }

            return View(orcamentoPedido);
        }

        // GET: OrcamentoPedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrcamentoPedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Mensagem")] OrcamentoPedido orcamentoPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orcamentoPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orcamentoPedido);
        }

        // GET: OrcamentoPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamentoPedido = await _context.PedidosOrcamento.FindAsync(id);
            if (orcamentoPedido == null)
            {
                return NotFound();
            }
            return View(orcamentoPedido);
        }

        // POST: OrcamentoPedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Mensagem")] OrcamentoPedido orcamentoPedido)
        {
            if (id != orcamentoPedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orcamentoPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrcamentoPedidoExists(orcamentoPedido.Id))
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
            return View(orcamentoPedido);
        }

        // GET: OrcamentoPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orcamentoPedido = await _context.PedidosOrcamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orcamentoPedido == null)
            {
                return NotFound();
            }

            return View(orcamentoPedido);
        }

        // POST: OrcamentoPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orcamentoPedido = await _context.PedidosOrcamento.FindAsync(id);
            _context.PedidosOrcamento.Remove(orcamentoPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrcamentoPedidoExists(int id)
        {
            return _context.PedidosOrcamento.Any(e => e.Id == id);
        }
    }
}
