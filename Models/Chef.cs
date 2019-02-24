using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models
{
  public class Chef
  {
    public int ChefId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [DataType(DataType.Date)]
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