using System.ComponentModel.DataAnnotations;

namespace PraksaVjezba.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
