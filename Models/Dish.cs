using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models
{
  public class Dish
  {
    public int DishId { get; set; }
    [Required]
    public string Name { get; set; }
    public int Tastiness { get; set; }
    public int Calories { get; set; }
    [Required]
    public string Description { get; set; }
    public int ChefId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // nav property for related Chef
    public Chef Chef { get; set; }

    // form property for selecting chef associated with Dish
    [NotMapped]
    public List<Chef> Chefs { get; set; }
  }
}