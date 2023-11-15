using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Genres
    {
        public int GenreId { get; set; }
        public string? MovieGenre { get; set; }
        public ICollection<Movies>? Movies { get; set; }
    }
}
