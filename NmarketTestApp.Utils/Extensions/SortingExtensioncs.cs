using System;
using System.Linq;
using System.Linq.Expressions;

namespace NmarketTestApp.Utils.Extensions
{
    public static class SortingExtensioncs
    {
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> query, string sortColumn, bool descending)
        {
            // динамически создаем: query.OrderBy(p =&gt; p.SortColumn)
            var parameter = Expression.Parameter(typeof(T), "p");

            string command = "OrderBy";

            if (descending)
            {
                command = "OrderByDescending";
            }

            Expression resultExpression = null;

            var property = typeof(T).GetProperty(sortColumn);
            // часть p.SortColumn
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);

            // часть p =&gt; p.SortColumn
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            // вызов "OrderBy" / "OrderByDescending" с лямдой сортировки
            resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { typeof(T), property.PropertyType },
               query.Expression, Expression.Quote(orderByExpression));

            return query.Provider.CreateQuery<T>(resultExpression);
        }

    }
}
