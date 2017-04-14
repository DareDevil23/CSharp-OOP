using AttributePropertyValidation.Attributes;
using AttributePropertyValidation.Models;

namespace AttributePropertyValidation.Models
{
    class Warrior
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Weapon Weapon { get; set; }
    }
}
