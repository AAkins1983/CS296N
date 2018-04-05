using System.ComponentModel.DataAnnotations;

namespace MagicPonySparkleLand.Models
{
    public class ContactFormInfo
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        public string Message { get; set; }
    }
}
