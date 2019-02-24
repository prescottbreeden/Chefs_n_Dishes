using System;
using System.Collections.Generic;

namespace ChefsDishes.Models
{
  public class Chef
  {
    public int ChefId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DoB { get; set; }
    public int Age 
    { 
      get { return DateTime.Now.Year - DoB.Year; }
    }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // nav property for related Dish objects
    public List<Dish> Dishes { get; set; }
  }
}