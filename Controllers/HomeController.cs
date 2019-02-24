using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
  public class HomeController : Controller
  {
    private ChefContext _dbContext;
    public HomeController(ChefContext context)
    {
      _dbContext = context;
    }

    [Route("")]
    [HttpGet]
    public IActionResult Chefs()
    {
      List<Chef> AllChefs = _dbContext.Chefs
        .Include(c => c.Dishes)
        .ToList();
      return View(AllChefs);
    }

    [Route("dishes")]
    [HttpGet]
    public IActionResult Dishes()
    {
      List<Dish> AllDishes = _dbContext.Dishes
        .Include(d => d.Chef)
        .ToList();
      return View(AllDishes);
    }

    [HttpGet("newchef")]
    public IActionResult NewChef()
    {
      return View();
    }

    [HttpGet("newdish")]
    public IActionResult NewDish()
    {
      return View(BuildDishForm());
    }

    [HttpPost("chef")]
    public IActionResult CreateChef(Chef chef)
    {
      if(ModelState.IsValid)
      {
        _dbContext.Chefs.Add(chef);
        _dbContext.SaveChanges();
        return RedirectToAction("Chefs");
      }
      return View("NewChef");
    }

    [HttpPost("dish")]
    public IActionResult CreateDish(Dish dish)
    {
      if(ModelState.IsValid)
      {
        _dbContext.Dishes.Add(dish);
        _dbContext.SaveChanges();
        return RedirectToAction("Dishes");
      }
      return View("NewDish", BuildDishForm());
    }

    public Dish BuildDishForm()
    {
      return new Dish()
      {
        Chefs = _dbContext.Chefs.ToList()
      };
    }

  }
}
