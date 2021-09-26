using System.ComponentModel.DataAnnotations;

namespace Fridge.API.Dtos.Product
{
    public class ProductAddDto
    {
        [Required(ErrorMessage = "Wartość {0} jest wymagana")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Wartość {0} jest wymagana")]
        [StringLength(200, ErrorMessage = "Wartość {0} musi mieć między {2} a {1} znaków", MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(300, ErrorMessage = "Wartość {0} może mieć maksymalnie {1} znaków")]
        public string Description { get; set; }
    }
}
