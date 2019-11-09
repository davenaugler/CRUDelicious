using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CRUDelicious.Models;
using Microsoft.AspNetCore.Mvc;


namespace CRUDelicious.Controllers
{
  public class HomeController : Controller
  {
    private CRUDeliciusContext dbContext;
    public HomeController(CRUDeliciusContext context)
    {
      dbContext = context;
    }
    // Route to Index.cshtml
    [HttpGet("")]
    public IActionResult Index()
    {
      List<Dish> AllDishes = dbContext.Dishes.ToList();
      AllDishes.Reverse();
      return View(AllDishes);
    }

    // Route to New.cshtml
    [HttpGet("new")]
    public IActionResult New()
    {
      // List<Dish> AllDishes = dbContext.Dishes.ToList();
      return View();
    }

    // Route that handles the Form inside New.cshtml in order 
    // to be able to Create a new Dish
    [HttpPost]
    public IActionResult Create(Dish newDish)
    {
      if (ModelState.IsValid)
      {
        dbContext.Add(newDish);
        System.Console.WriteLine(newDish.Name);
        dbContext.SaveChanges();
        System.Console.WriteLine($"{newDish.Tastiness} ###########################################");
        return Redirect("/");
      }
      else
      {
        return View("New");
      }


    }

    // Route to view the dish selected from the Index.cshtml
    // to viewe it in View.cshtml
    [HttpGet("edit/{TheDishsID}")]
    public IActionResult EditPage(int TheDishsID)
    {
      Dish singleDish = dbContext.Dishes.FirstOrDefault(dish => dish.dishId == TheDishsID);
      return View("Edit", singleDish);
    }

    [HttpPost]
    public IActionResult Edit(Dish thedish)
    {

      dbContext.Dishes.Update(thedish);
      dbContext.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("{TheFrikenDishId}")]
    public IActionResult ViewDish(int TheFrikenDishId)
    {
      Dish dish = dbContext.Dishes.Where(a => a.dishId == TheFrikenDishId).Single();

      return View(dish);
    }

    // Delete route inside View.cshtml
    [HttpPost("delete/{TheDishsID}")]
    public IActionResult DeleteDish(int TheDishsID)
    {
      Dish GrabbedDish = dbContext.Dishes.SingleOrDefault(dish => dish.dishId == TheDishsID);
      dbContext.Dishes.Remove(GrabbedDish);
      dbContext.SaveChanges();
      return Redirect("/");
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}