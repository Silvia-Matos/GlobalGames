namespace GlobalGames.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Dados;
    using Dados.Entidades;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    
    public class JogoInscricoesController : Controller
    {
        private readonly DataContext _context;

        public JogoInscricoesController(DataContext context)
        {
            _context = context;
        }

        // GET: JogoInscricoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.InscricoesJogo.ToListAsync());
        }

        // GET: JogoInscricoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoInscricao = await _context.InscricoesJogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogoInscricao == null)
            {
                return NotFound();
            }

            return View(jogoInscricao);
        }



        // POST: JogoInscricoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Apelido,Morada,Localidade,CC,DataNascimento")] JogoInscricao jogoInscricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jogoInscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Inscricao", "Home");



            }
            return RedirectToAction("Inscricao", "Home");

        }

        // GET: JogoInscricoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoInscricao = await _context.InscricoesJogo.FindAsync(id);
            if (jogoInscricao == null)
            {
                return NotFound();
            }
            return View(jogoInscricao);
        }

        // POST: JogoInscricoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Apelido,Morada,Localidade,CC,DataNascimento")] JogoInscricao jogoInscricao)
        {
            if (id != jogoInscricao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogoInscricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogoInscricaoExists(jogoInscricao.Id))
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
            return View(jogoInscricao);
        }

        // GET: JogoInscricoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogoInscricao = await _context.InscricoesJogo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jogoInscricao == null)
            {
                return NotFound();
            }

            return View(jogoInscricao);
        }

        // POST: JogoInscricoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogoInscricao = await _context.InscricoesJogo.FindAsync(id);
            _context.InscricoesJogo.Remove(jogoInscricao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogoInscricaoExists(int id)
        {
            return _context.InscricoesJogo.Any(e => e.Id == id);
        }
    }
}
