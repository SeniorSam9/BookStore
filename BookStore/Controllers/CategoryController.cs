using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Category> categoryList =  _dbContext.Categories.ToList();
            // pass it to the view
            return View(categoryList);
        }
    }
}
