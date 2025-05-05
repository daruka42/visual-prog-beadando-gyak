using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualProgBeadandoGyak.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Nationality { get; set; }
        public DateTime? BirthDate { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
