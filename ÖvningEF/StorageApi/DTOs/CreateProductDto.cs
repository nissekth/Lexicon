
using System.ComponentModel.DataAnnotations;

public class CreateProductDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(30, MinimumLength = 3,
        ErrorMessage = "Name has to be 3-30 characters long")]
    public string Name {get; set;}

    [Required(ErrorMessage = "Price is required")]
    [Range(1, 100000,
        ErrorMessage = "Price must be within range 1-100.000")]
    public int Price {get; set;}

    [Required(ErrorMessage = "Category is required")]
    [StringLength(25, MinimumLength = 2, 
	ErrorMessage = "Category must be 2-25 characters long")]
    public string Category {get; set;}

    [Required(ErrorMessage = "Shelf is required")]
    [StringLength(3, MinimumLength = 2, 
	ErrorMessage = "Shelf must be 2-3 characters long")]
    public string Shelf {get; set;}

    [Range(0, 50000,
        ErrorMessage = "Count cannot be negative")]
    public int Count {get; set;}

    [Required(ErrorMessage = "Description is required")]
    [StringLength(500, 
	ErrorMessage = "Description must be less than 500 characters")]
    public string Description {get; set;}
}

