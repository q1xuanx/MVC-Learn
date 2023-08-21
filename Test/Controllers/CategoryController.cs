using Azure.Messaging;
using Microsoft.AspNetCore.Mvc;
using Test.DataAccess.Data;
using Test.Models;

namespace Test.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "Display Order Can't The Same The Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? findId = _db.Categories.Find(id);
            if (findId == null)
            {
                return NotFound();
            }
            return View(findId);
        }
        [HttpPost,ActionName("Edit")]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order Can't The Same The Name");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? findId = _db.Categories.Find(id);
            if (findId == null)
            {
                return NotFound();
            }
            return View(findId);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? Id)
        {
            Category? findToDel = _db.Categories.Find(Id);
            if (findToDel == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(findToDel);
            _db.SaveChanges();
            TempData["success"] = "Category deleted";
            return RedirectToAction("Index");    
        }

    }
}
