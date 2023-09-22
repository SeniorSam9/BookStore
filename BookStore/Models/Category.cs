using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    // names in models do not have to follow nay conventions
    // models represent DB
    public class Category
    {
        // primary key
        // however .net deals with any prop that has "Id" as a key by default
        // so [Key] is not required here
        [Key] 
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
