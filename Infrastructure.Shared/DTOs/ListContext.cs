using System.Collections.Generic;

namespace Infrastructure.Shared.DTOs
{
    public class PageableCollection<T>
    {
        public List<T> Items { get; set; }

        public int Total { get; set; }
         
    }
}
