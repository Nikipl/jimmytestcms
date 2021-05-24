using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace JimmyTestCMS.Service.Common
{
    public static class SortingQueryableExtensions
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> queryable, Sorting sorting)
        {
            if (queryable == null) {
                throw new ArgumentException($"{nameof(queryable)} should not be null");
            }

            if (sorting == null) {
                throw new ArgumentException($"{nameof(sorting)} should not be null");
            }

            if (string.IsNullOrEmpty(sorting.Field)) {
                throw new InvalidOperationException($"{nameof(sorting.Field)} should have a value");
            }

            var property = TypeCache<T>.Properties.GetValueOrDefault(sorting.Field);
            if (property == null) {
                throw new InvalidOperationException($"Field {sorting.Field} not found in type {TypeCache<T>.Name}");
            }

            var parameterExpression = Expression.Parameter(TypeCache<T>.Type);
            var propertyAccess = Expression.Property(parameterExpression, property.Name);
            var lambda = Expression.Lambda(propertyAccess, parameterExpression);
            var method = sorting.Direction == OrderingDirection.Ascending
                ? GenericOrderByMethod
                : GenericOrderByDescendingMethod;
            method = method.MakeGenericMethod(TypeCache<T>.Type, property.PropertyType);
            return (IQueryable<T>) method.Invoke(null, new object[] { queryable, lambda });
        }

        private static readonly MethodInfo GenericOrderByMethod = typeof(Queryable).GetMethods()
            .First(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);

        private static readonly MethodInfo GenericOrderByDescendingMethod = typeof(Queryable).GetMethods()
            .First(m => m.Name == "OrderByDescending" && m.GetParameters().Length == 2);

        private static class TypeCache<T>
        {
            public static readonly Type Type = typeof(T);
            public static readonly string Name = Type.Name;
            public static readonly IReadOnlyDictionary<string, PropertyInfo> Properties =
                Type.GetProperties().ToDictionary(p => p.Name);
        }
    }
}
