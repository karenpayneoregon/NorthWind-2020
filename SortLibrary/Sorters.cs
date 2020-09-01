using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SortLibrary
{
    public static class Sorters
    {
        /// <summary>
        /// Performs a sort by property name as a string
        /// </summary>
        /// <typeparam name="T">Type to perform sorting on</typeparam>
        /// <param name="list">List of T</param>
        /// <param name="propertyName">Valid property name in T</param>
        /// <param name="sortDirection">ascending or descending order, ascending is the default direction</param>
        /// <returns>list sorted by property name in specified order</returns>
        public static List<T> SortByPropertyName<T>(this List<T> list, string propertyName, SortDirection sortDirection)
        {

            var param = Expression.Parameter(typeof(T), "item");

            Expression<Func<T, object>> sortExpression = Expression.Lambda<Func<T, object>>(
                Expression.Convert(Expression.Property(param, propertyName), typeof(object)), param);

            list = sortDirection == SortDirection.Ascending ? 
                list.AsQueryable().OrderBy(sortExpression).ToList() : 
                list.AsQueryable().OrderByDescending(sortExpression).ToList();

            return list;

        }

    }
}
