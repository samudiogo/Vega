using System.Collections.Generic;

namespace Vega.Domain.Queries
{
    public class QueryResult<T> where T: class 
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}