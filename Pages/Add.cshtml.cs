using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using gameDb.Models;
using gameDb.Data;
using Microsoft.IdentityModel.Tokens;

namespace gameDb.Pages
{
    public class AddModel : PageModel
    {
        private readonly GameDbContext _db;

        public AddModel(GameDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Game NewGame { get; set; }

        [TempData]
        public string? msg { get; set; }

        public void OnGet()
        {
            if (msg != null)
            {
                
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (NewGame.name.IsNullOrEmpty())
            {
                msg = "Please fill all fields";
                return RedirectToPage();
            }

            if (NewGame.genre.IsNullOrEmpty())
            {
                msg = "Please fill all fields";
                return RedirectToPage();
            }

            _db.Games.Add(NewGame);
            _db.SaveChanges();

            msg = "Game added successfully.";
            return RedirectToPage();
        }
    }
}
