using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;


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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            // custom validation
            if (category.Name == category.DisplayOrder.ToString())
            {
                // key, value
                // key is attribute of the category class
                // value is the displayed message
                ModelState.AddModelError("Name", "Category name and Display order are matching!!!");
            }
            if (category.Name != null && category.Name.ToLower().Equals("test"))
            {
                // kind of custom error (not related to any attribute)
                ModelState.AddModelError("", "test is not valid name!");
            }
            {

            }
            // ModelState.IsValid will check the validations that we inserted in category model
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            /// else keep us in the same view with error message displayed
            return View();
            
        }
    }
}
