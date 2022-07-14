using System.ComponentModel.DataAnnotations;

namespace PraksaVjezba.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(24), MinLength(5),Required]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country country { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
