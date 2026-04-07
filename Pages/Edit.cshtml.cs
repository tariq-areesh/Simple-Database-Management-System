using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gameDb.Models;
using gameDb.Data;


namespace Edit.Pages
{
    public class EditModel : PageModel
    {
        private readonly GameDbContext _db;

        public EditModel(GameDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Game GameInfo { get; set; }

        public IActionResult OnGet(int id)
        {
            GameInfo = _db.Games.Find(id);

            if (GameInfo == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var existing = _db.Games.Find(GameInfo.id);
            if (existing == null)
                return NotFound();
            
            existing.name = GameInfo.name;
            existing.genre = GameInfo.genre;
            _db.SaveChanges();

            return RedirectToPage("/gamesList");
        }

    }
}
