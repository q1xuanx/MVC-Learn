using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazerWeb.Data;
using RazerWeb.Models;

namespace RazerWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Categories { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Categories = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            Category Obj = _db.Categories.Find(Categories.Id);
            if (Obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.Categories.Remove(Obj);
                _db.SaveChanges();
                TempData["success"] = "Deleted Success";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
