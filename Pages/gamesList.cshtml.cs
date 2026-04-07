using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gameDb.Models;
using gameDb.Data;
using Microsoft.EntityFrameworkCore;


namespace gameDb.Pages
{
    public class gamesListModel : PageModel
    {
        private readonly GameDbContext _db;

        public List<Game> Games { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? gameGenre { get; set; }
        public gamesListModel(GameDbContext db)
        {
            _db = db;
        }

        /*public void OnGet()
        {
            Games = _db.Games.ToList();

        }*/

        public IActionResult OnPostDelete(int id)
        {
            var gameToDel = _db.Games.Find(id);
            if (gameToDel != null)
            {
                _db.Games.Remove(gameToDel);
                _db.SaveChanges();
            }
            return RedirectToPage();
        }

        public async Task OnGetAsync()
        {
            Games = _db.Games.ToList();

            IQueryable<String> genQuery = from game in _db.Games orderby game.genre select game.genre;

            var gamesQuery = from game in _db.Games select game;
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                gamesQuery = gamesQuery.Where(s => s.name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(gameGenre))
            {
                
            }

            Games = await gamesQuery.ToListAsync();
        }
    }
}
