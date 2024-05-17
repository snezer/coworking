using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coworking.DA.Models.Paging
{
    public class PagedItems<T>
    {
        public int Total { get; set; }
        public T[]? Items { get; set; }
        public string? ErrMess { get; set; }
    }
}
