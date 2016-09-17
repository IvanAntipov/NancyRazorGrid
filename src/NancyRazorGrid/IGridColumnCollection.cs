using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NancyRazorGrid
{
    public interface IGridColumnCollection<T> : IEnumerable<IColumn<T>>//IGridColumnCollection, IEnumerable<IGridColumn>, IEnumerable
    {
        //IGridColumn<T> Add(IGridColumn<T> column);

        IColumn<T> Add();

        //IGridColumn<T> Add(bool hidden);

        IColumn<T> Add<TKey>(Expression<Func<T, TKey>> constraint);

        //IGridColumn<T> Add<TKey>(Expression<Func<T, TKey>> constraint, string columnName);

        //IGridColumn<T> Add<TKey>(Expression<Func<T, TKey>> constraint, bool hidden);

        //IGridColumn<T> Add(PropertyInfo pi);

        //IGridColumn<T> Insert(int position, IGridColumn<T> column);

        //IGridColumn<T> Insert<TKey>(int position, Expression<Func<T, TKey>> constraint);

        //IGridColumn<T> Insert<TKey>(int position, Expression<Func<T, TKey>> constraint, string columnName);

        //IGridColumn<T> Insert<TKey>(int position, Expression<Func<T, TKey>> constraint, bool hidden);
    }
}