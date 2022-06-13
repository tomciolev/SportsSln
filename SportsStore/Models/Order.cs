using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();
        [Required(ErrorMessage = "Please enter a name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter a street")]
        public string? Street { get; set; }
        [Required(ErrorMessage = "Please enter a apartment number")]
        public int? ApartmentNumber { get; set; }
        [Required(ErrorMessage = "Please enter a city name")]
        public string? City { get; set; }
        [Required(ErrorMessage = "Please enter a zip code")]
        public string? Zip { get; set; }
        [Required(ErrorMessage = "Please enter a country name")]
        public string? Country { get; set; }
        [BindNever]
        public bool Shipped { get; set; } = false;

    }

}
