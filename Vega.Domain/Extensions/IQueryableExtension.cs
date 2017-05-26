using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Vega.Domain.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnMap)
        {
            if (string.IsNullOrEmpty(queryObj.SortBy) || !columnMap.ContainsKey(queryObj.SortBy))
                return query;

            return queryObj.IsSortAscending
                ? query.OrderBy(columnMap[queryObj.SortBy])
                : query.OrderByDescending(columnMap[queryObj.SortBy]);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObject)
        {
            if (queryObject.Page <= 0) queryObject.Page = 1;

            if (queryObject.PageSize <= 0) queryObject.PageSize = 10;

            return query.Skip((queryObject.Page - 1) * queryObject.PageSize).Take(queryObject.PageSize);

        }
    }
}