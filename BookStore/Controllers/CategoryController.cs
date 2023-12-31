﻿using BookStore.DataAccess.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


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
            List<Category> categoryList = _dbContext.Categories.ToList();
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
                // asp validation needs to be set as "All" to be rendered
                ModelState.AddModelError("", "test is not valid name!");
            }
            {

            }
            // ModelState.IsValid will check the validations that we inserted in category model
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category Created Successfully!";
                return RedirectToAction("Index");
            }
            /// else keep us in the same view with error message displayed
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // one way to get the category from the DB is by primary key
            Category? categoryFromDb = _dbContext.Categories.Find(id);
            // firstordefault if to get data from any attribute not necesserily the primary key
            //Category? categoryFromDb2 = _dbContext.Categories.FirstOrDefault(c => c.Name == Name);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                // we dont need to look for the id manually
                // it automatically finds category id and updates it
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
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
            Category? categoryFromDb = _dbContext.Categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _dbContext.Categories.Remove(categoryFromDb);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
