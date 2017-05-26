using System.Collections.Generic;

namespace VegaApi.ViewModels
{
    public class QueryResultViewModel<T> where T : class
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}