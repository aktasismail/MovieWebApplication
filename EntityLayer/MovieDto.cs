using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public record MovieDto
    {
        public int MovieId { get; init; }
        [Required(ErrorMessage ="Lütfen film adını giriniz")]
        public string? Moviename { get; init; }
        [Required(ErrorMessage = "Lütfen detayları giriniz")]
        public string? MovieDetail { get; init; }
        [Required(ErrorMessage = "Lütfen oyuncuları giriniz")]
        public string? Cast { get; init; }
        public string? Director { get; init; }
        public string? ImageUrl { get; set; }
        public string? Duration { get; init; }
        public string? MovieSource { get; init; }
        public int? Year { get; init; }
        public decimal ImdbRate { get; init; }
        public int? GenreId { get; init; }
    }
}
