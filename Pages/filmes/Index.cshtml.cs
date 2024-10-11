using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using filmeApp.Models;
using filmesApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace filmeApp.Pages_filmes
{
    public class IndexModel : PageModel
    {
        private readonly filmesApp.Data.filmesAppContext _context;

        public IndexModel(filmesApp.Data.filmesAppContext context)
        {
            _context = context;
        }

        public IList<Filme> Filme { get;set; } = default!;

        [BindProperty(SupportsGet =true)]
        public string? TextoFiltro {get; set;} 
        public SelectList Generos {get; set;}

        [BindProperty(SupportsGet = true)]
        public string GeneroFilme {get; set;}

        

        public async Task OnGetAsync()
        {
            IQueryable<string> generoQuery = from f in _context.Filme
                                             orderby f.Genero
                                             select f.Genero;

            var filmes = from f in _context.Filme select f;
            if(!string.IsNullOrEmpty(TextoFiltro)){
                filmes = filmes.Where(s => s.Titulo.Contains(TextoFiltro));
            }

            if(!string.IsNullOrEmpty(GeneroFilme)){
                filmes = filmes.Where(g => g.Genero == GeneroFilme);
            }

            Generos = new SelectList(await generoQuery.Distinct().ToListAsync());            
            Filme = await filmes.ToListAsync();
            //Filme = await _context.Filme.ToListAsync();
        }
    }
}
