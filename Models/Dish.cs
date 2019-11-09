using System.ComponentModel.DataAnnotations;
using System;

namespace CRUDelicious.Models
{
    public class Dish
    {
      [Key]
      public int dishId {get; set;}


      [Required(ErrorMessage="Name of dish is required")]
      public string Name {get; set;}


      [Required(ErrorMessage="Chef's name is required")]
      public string Chef {get; set;}


      [Required(ErrorMessage="Tastiness value 1-5 is required")]
      [Range(1,5, ErrorMessage="Tastiness value 1-5 is required")]
      public int? Tastiness {get; set;}

      [Required]
      [Range(1,5000, ErrorMessage="Calories need to be greater than 0")]
      public int? Calories {get; set;}


      [Required(ErrorMessage="Description is required")]
      public string Description {get; set;}


      public DateTime CreatedAt {get; set;} = DateTime.Now;
      public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }
}