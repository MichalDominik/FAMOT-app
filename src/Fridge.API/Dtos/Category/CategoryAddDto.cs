using System.ComponentModel.DataAnnotations;

namespace Fridge.API.Dtos.Category
{
    public class CategoryAddDto
    {
        [Required(ErrorMessage = "Wartość {0} jest wymagana")]
        [StringLength(100, ErrorMessage = "Wartość {0} musi mieć między {2} a {1} znaków", MinimumLength = 2)]
        public string Name { get; set; }
    }
}
