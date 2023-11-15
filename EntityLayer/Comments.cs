using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Comments
    {
        public int CommentId { get; set; }
        public string? Tittle { get; set; }
        public string? CommentText { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movies Movies { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
