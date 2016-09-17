using System;

namespace NancyRazorGrid
{
    public interface IColumn<out T>
    {
        IColumn<T> Titled(string title);

        IColumn<T> Encoded(bool encode);

        IColumn<T> Sanitized(bool sanitize);

        IColumn<T> SetWidth(string width);

        IColumn<T> SetWidth(int width);

        IColumn<T> Css(string cssClasses);

        IColumn<T> RenderValueAs(Func<T, string> constraint);

        IColumn<T> Format(string pattern);
        IColumn<T> Sortable(bool sort);
    }

    public interface IColumn
    {
        string Title { get; }

        string Name { get; set; }

        string Width { get; set; }

        bool EncodeEnabled { get; }

        bool SanitizeEnabled { get; }

        //        IGridColumnHeaderRenderer HeaderRenderer { get; set; }

        //        IGridCellRenderer CellRenderer { get; set; }

        //        IGridCell GetCell(object instance);
    }
}