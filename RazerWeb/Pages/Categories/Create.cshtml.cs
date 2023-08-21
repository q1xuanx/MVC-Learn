using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazerWeb.Data;
using RazerWeb.Models;

namespace RazerWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Categories { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            _db.Categories.Add(Categories);
            _db.SaveChanges();
            TempData["success"] = "Created Success";
            return RedirectToPage("Index");
        }
    }
}
