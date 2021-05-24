using System;
using System.Linq;
using JimmyTestCMS.Service.Common;
using NUnit.Framework;

namespace JimmyTestCMS.Tests
{
    public class SortingQueryableExtensionsTests
    {
        [Test]
        public void WithCorrectInput_RunsWithoutException()
        {
            var query = CreateQuery();
            var resultQuery = query.Sort(new Sorting { Field = nameof(SomeType.Foo) });
            Assert.IsNotNull(resultQuery.ToList());
        }

        [Test]
        public void WithNullSortingValue_ThrowsArgumentException()
        {
            var query = CreateQuery();
            Assert.Throws<ArgumentException>(() => query.Sort(null));
        }

        [Test]
        public void WithNullFieldName_ThrowsInvalidOperationException()
        {
            var query = CreateQuery();
            Assert.Throws<InvalidOperationException>(() => query.Sort(new Sorting { Field = null }));
        }

        [Test]
        public void WithIncorrectFieldName_ThrowsInvalidOperationException()
        {
            var query = CreateQuery();
            Assert.Throws<InvalidOperationException>(() => query.Sort(new Sorting { Field = "Bar" }));
        }

        [Test]
        public void WithCorrectInput_SortsAscending()
        {
            var query = CreateQuery(5, 4, 1);
            var result = query
                .Sort(new Sorting { Field = nameof(SomeType.Foo) })
                .Select(st => st.Foo)
                .ToList();
            CollectionAssert.IsOrdered(result);
        }

        [Test]
        public void WithCorrectInput_SortsDescending()
        {
            var query = CreateQuery(3, 5, 1);
            var result = query
                .Sort(new Sorting { Field = nameof(SomeType.Foo), Direction = OrderingDirection.Descending })
                .Select(st => st.Foo)
                .ToList();
            CollectionAssert.AreEqual(new[] { 5, 3, 1 }, result);
        }

        private IQueryable<SomeType> CreateQuery(params int[] values)
        {
            return values.Select(v => new SomeType { Foo = v }).AsQueryable();
        }
    }

    public class SomeType
    {
        public int Foo { get; set; }
    }
}
