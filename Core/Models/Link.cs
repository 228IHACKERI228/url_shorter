using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Link
    {
        public int Id { get; set; }

        [Required]
        [Url(ErrorMessage = "Некорректный URL")]
        public string LongUrl { get; set; } = string.Empty;

        public string ShortUrl { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int ClickCount { get; set; }
    }
}
