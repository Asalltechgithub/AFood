using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShop.Backoffice.Context;
using WebShop.Backoffice.Entities;

namespace WebShop.Backoffice.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;
        private string Caminhoservidor;
        private string Caminhointerno;

        public ProdutosController(AppDbContext context, IWebHostEnvironment sistema)
        {
            _context = context;

             Caminhointerno = sistema.WebRootPath;

             Caminhoservidor = "C:\\dev\\BlazorShop-master\\BlazorShop.Web\\wwwroot";
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Produtos.Include(p => p.Categoria);



            return View(await appDbContext.ToListAsync());
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,ImagemUrl,Preco,Quantidade,CategoriaId")] Produto produto, IFormFile foto)
        {

            var categoria = await _context.Categorias
               .FirstOrDefaultAsync(m => m.Id == produto.CategoriaId);

            produto.ImagemUrl = Upload(foto,categoria.Nome);


            if (ModelState.IsValid)
            {
              
               var cortada = produto.ImagemUrl.Replace("C:\\dev\\BlazorShop-master\\BlazorShop.Web\\wwwroot\\", "");
                
                produto.ImagemUrl = cortada;
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", produto.CategoriaId);
            return View(produto);
        }


        public string Upload(IFormFile foto,string NomeCategoria)
        {

            string CaminhoSave = Caminhoservidor + $"\\Imagems\\{NomeCategoria}\\".Trim();
            string CaminhoSave2 = Caminhointerno + $"\\Imagems\\{NomeCategoria}\\".Trim();
            string novoNomeParaImagem = Guid.NewGuid().ToString() + "_" + foto.FileName;
            var final = string.Empty;
            if (!Directory.Exists(CaminhoSave))
            {
                Directory.CreateDirectory(CaminhoSave);
            }

            if (!Directory.Exists(CaminhoSave2))
            {
                Directory.CreateDirectory(CaminhoSave2);
            }
            using (var stream = System.IO.File.Create(CaminhoSave + novoNomeParaImagem))
            {
                foto.CopyToAsync(stream);
                final = CaminhoSave + novoNomeParaImagem;
            }
            using (var stream = System.IO.File.Create(CaminhoSave2 + novoNomeParaImagem))
            {
                foto.CopyToAsync(stream);
                
            }


            return final;
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", produto.CategoriaId);
            return View(produto);
        }




        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,ImagemUrl,Preco,Quantidade,CategoriaId")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Id", produto.CategoriaId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'AppDbContext.Produtos'  is null.");
            }
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }





    }
}
