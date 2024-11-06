using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.UI.Models;

public class Customer
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^(\+?\d{1,4}[\s-]?)?(\(?\d{2,3}\)?[\s-]?)?(\d{3}[\s-]?)?\d{3,4}$", ErrorMessage = "Invalid phone number. Please enter a valid phone number.")]
    public string? Phone { get; set; }
}