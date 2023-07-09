using System.ComponentModel.DataAnnotations;

namespace SensitivewordsAPI.Models
{
    public class SensitiveWordItem
    {
        [Key]
        public int Id { get; set; }
        public string? Word { get; set; }
    }
}
