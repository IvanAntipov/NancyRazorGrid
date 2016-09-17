using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NancyRazorGrid
{
    public class GridColumnCollection<T> : IGridColumnCollection<T>
    {
        private readonly IList<Column<T>> _columns = new List<Column<T>>();
        public IColumn<T> Add()
        {
            var column = new Column<T>("");
            _columns.Add(column);
            return column;
        }

        public IColumn<T> Add<TKey>(Expression<Func<T, TKey>> constraint)
        {
            var compiled = constraint.Compile();
            var column = new Column<T>(((MemberExpression)constraint.Body).Member.Name);
            column.RenderValueAs(
                i => compiled(i)
                    ?.ToString() ?? "");
            _columns.Add(column);
            return column;
        }

        public IEnumerator<IColumn<T>> GetEnumerator()
        {
            return _columns.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IReadOnlyCollection<Column<T>> GetColumns()
        {
            return _columns.ToArray();
        } 
    }
}