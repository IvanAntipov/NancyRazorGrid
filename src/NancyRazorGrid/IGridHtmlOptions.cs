using System;
using Nancy.ViewEngines.Razor;

namespace NancyRazorGrid
{
    public interface IGridHtmlOptions<T> : IHtmlString
    {
        IGridHtmlOptions<T> Columns(Action<IGridColumnCollection<T>> columnBuilder);

        //IGridHtmlOptions<T> WithPaging(int pageSize);

        //IGridHtmlOptions<T> WithPaging(int pageSize, int maxDisplayedItems);

        //IGridHtmlOptions<T> WithPaging(int pageSize, int maxDisplayedItems, string queryStringParameterName);

        //IGridHtmlOptions<T> Sortable();

        IGridHtmlOptions<T> Sortable(bool enable);

        //IGridHtmlOptions<T> Filterable();

        //IGridHtmlOptions<T> Filterable(bool enable);

        //IGridHtmlOptions<T> Selectable(bool set);

        //IGridHtmlOptions<T> EmptyText(string text);

        //IGridHtmlOptions<T> SetLanguage(string lang);

        IGridHtmlOptions<T> SetRowCssClasses(Func<T, string> contraint);

        //IGridHtmlOptions<T> Named(string gridName);

        //IGridHtmlOptions<T> AutoGenerateColumns();

        //IGridHtmlOptions<T> WithMultipleFilters();

        //string Render();
        IGridColumnCollection<T> SetTableAttributes(object o);

    }
}