/*
 * Demonstrates implementing a Between operation in Entity Framework/Entity Framework Core.
 */
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace EntityCoreExtensions
{
    public static class GeneralExtensions
    {
        /// <summary>
        /// Use the extension method to implement the Between operation in EF
        /// </summary>
        /// <typeparam name="TSource">Type of the entity</typeparam>
        /// <typeparam name="TKey">Type of the return value</typeparam>
        /// <param name="source">The entity used to apply the method</param>
        /// <param name="keySelector">The lambda expression used to get the return value</param>
        /// <param name="low">Low boundary of the return value</param>
        /// <param name="high">High boundary of the return value</param>
        /// <returns>return the IQueryable</returns>
        public static IQueryable<TSource> Between<TSource, TKey>(this IQueryable<TSource> source, Expression<Func<TSource, TKey>> keySelector, TKey low, TKey high) where TKey : IComparable<TKey>
        {
            // Get a ParameterExpression node of the TSource that is used in the expression tree
            ParameterExpression sourceParameter = Expression.Parameter(typeof(TSource));

            // Get the body and parameter of the lambda expression
            Expression body = keySelector.Body;
            ParameterExpression parameter = null;

            if (keySelector.Parameters.Count > 0)
            {
                parameter = keySelector.Parameters[0];
            }

            // Get the Compare method of the type of the return value
            MethodInfo compareMethod = typeof(TKey).GetMethod("CompareTo", new[] { typeof(TKey) });

            // Expression.LessThanOrEqual and Expression.GreaterThanOrEqua method are only used in
            // the numeric comparision. If we want to compare the non-numeric type, we can't directly 
            // use the two methods. 
            //
            // So first use the Compare method to compare the objects, and the Compare method 
            // will return a int number. Then we can use the LessThanOrEqual and GreaterThanOrEqua method.
            // For this reason, we ask all the TKey type implement the IComparable<> interface.
            Expression upper = Expression.LessThanOrEqual(Expression.Call(body, compareMethod, Expression.Constant(high)), Expression.Constant(0, typeof(int)));
            Expression lower = Expression.GreaterThanOrEqual(Expression.Call(body, compareMethod, Expression.Constant(low)), Expression.Constant(0, typeof(int)));

            Expression andExpression = Expression.And(upper, lower);

            // Get the Where method expression.
            MethodCallExpression whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new Type[] { source.ElementType },
                source.Expression,
                Expression.Lambda<Func<TSource, bool>>(andExpression,
                new ParameterExpression[] { parameter }));

            return source.Provider.CreateQuery<TSource>(whereCallExpression);
        }
    }
}

