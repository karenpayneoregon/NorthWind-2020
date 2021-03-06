﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FirstUpSorting.Classes;

namespace FirstUpSorting.LanguageExtensions
{
    public static class Sorters
    {
        public static List<T> Sort<T>(this List<T> list, string propertyName, SortDirection sortDirection)
        {

            var param = Expression.Parameter(typeof(T), "item");

            Expression<Func<T, object>> sortExpression = Expression.Lambda<Func<T, object>>(
                Expression.Convert(Expression.Property(param, propertyName), typeof(object)), param);


            list = sortDirection == SortDirection.Descending ? 
                list.AsQueryable().OrderBy(sortExpression).ToList() : 
                list.AsQueryable().OrderByDescending(sortExpression).ToList();

            return list;

        }

    }
}
