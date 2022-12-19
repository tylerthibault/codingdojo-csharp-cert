using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using _26ProductsAndCategories.Models;

namespace _26ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return RedirectToAction("ProductShow");
    }

    // Product Section ***********************

    [HttpGet("/products")]
    public IActionResult ProductShow()
    {
        List<Product> AllProducts = _context.Products.ToList();
        MyViewModel MyModel = new MyViewModel
        {
            AllProducts = _context.Products.ToList(),
        };
        return View("Index", MyModel);
    }

    [HttpPost("/product/create")]
    public IActionResult ProductCreate(Product product)
    {
        if (!ModelState.IsValid)
        {
            return ProductShow();
        }
        _context.Add(product);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("/product/{productId}")]
    public IActionResult ProductShowOne(int ProductId)
    {
        Product? product = _context.Products
            .Include(ass => ass.AllCategories)
            .ThenInclude(ass => ass.Category)
            .FirstOrDefault(p => p.ProductId == ProductId);

        MyViewModel MyView = new MyViewModel
        {
            AllCategories = _context.Categories.ToList(),
            Product = product,
        };

        return View("ProductShowOne", MyView);
    }


    // Categories Section ******************************

    [HttpGet("/categories")]
    public IActionResult CategoriesShow()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllCategories = _context.Categories.ToList()
        };
        return View("CategoriesShow", MyModel);
    }

    [HttpPost("/categories/create")]
    public IActionResult CategoriesCreate(Category NewCat)
    {
        if (!ModelState.IsValid)
        {
            return CategoriesShow();
        }
        _context.Add(NewCat);
        _context.SaveChanges();
        return RedirectToAction("CategoriesShow");
    }

    [HttpGet("/category/{CategoryId}")]
    public IActionResult CategoryShowOne(int CategoryId)
    {
        Category? Category = _context.Categories
            .Include(x => x.AllProducts)
            .ThenInclude(x => x.Product)
            .FirstOrDefault(c => c.CategoryId == CategoryId);

        MyViewModel MyModel = new MyViewModel
        {
            AllProducts = _context.Products.ToList(),
            Category = Category,
        };
        return View("CategoryShowOne", MyModel);
    }

    [HttpPost("/association/create/{origin}")]
    public IActionResult AssociationCreate(Association association, string origin)
    {
        if (!ModelState.IsValid)
        {
            if (origin == "categories")
            {
                return Redirect($"/category/{association.CategoryId}");
            }
            else 
            {
                return Redirect($"/product/{association.ProductId}");
            }
        }

        _context.Add(association);
        _context.SaveChanges();

        if (origin == "categories")
        {
            return Redirect($"/category/{association.CategoryId}");
        }
        else 
        {
            return Redirect($"/product/{association.ProductId}");
        }
    }
}
