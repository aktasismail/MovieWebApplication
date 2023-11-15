using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.RequestParameter
{
    public class MovieParameter:RequestParameter
    {
        public int? GenreId { get; set; }
        public uint MinRate { get; set; } = 1;
        public uint MaxRate { get; set; } = 10;
        public bool ValidRate => MaxRate > MinRate;
        public String? SearchKey{ get; set; }
    }
}
