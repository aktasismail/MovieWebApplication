using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.RequestParameter
{
    public abstract class RequestParameter
    {
        public int PageNumber { get; set; } = 1;
        private int _pageSize;
        public int PageSize
        {
            get;
            set;
        } = 4;
    }
}
