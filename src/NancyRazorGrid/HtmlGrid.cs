using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using Nancy.ViewEngines.Razor;

namespace NancyRazorGrid
{
    public class HtmlGrid<T> : IGridHtmlOptions<T>
    {
        private readonly Nancy.ViewEngines.Razor.HtmlHelpers _helpers;
        private readonly IEnumerable<T> _items;
        private Func<T, string> _rowClasses;
        private Action<IGridColumnCollection<T>> _columnBuilder=_ =>{};
        private static readonly Sanitizer Sanitizer = new Sanitizer();

        public HtmlGrid(Nancy.ViewEngines.Razor.HtmlHelpers helpers, IEnumerable<T> items)
        {
            _helpers = helpers;
            _items = items;
        }

        public string ToHtmlString()
        {
            var columns = new GridColumnCollection<T>();
            _columnBuilder(columns);



            var sb = new StringBuilder();

            sb.AppendLine("<table data-razor-grid >");


            RenderHeader(sb, columns,false);
            RenderHeader(sb, columns,true);

            sb.AppendLine("<tbody>");
            foreach (var item in _items)
            {
                var rowClassesAttribute = _rowClasses == null
                    ? ""
                    : string.Format($" class={_rowClasses}");

                sb.AppendLine($"<tr{rowClassesAttribute}>");

                foreach (var column in columns.GetColumns())
                {

                    sb.AppendLine("<td>");
                    RenderColumnValue(sb, column, item);
                    sb.AppendLine("</td>");

                }
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("</tbody>");


            sb.AppendLine("</table>");
            return sb.ToString();
        }

        private void RenderColumnValue(StringBuilder sb, Column<T> column, T item)
        {
            var value = column.Renderer(item);
            var sanitized = (!column.Encode &&column.Sanitize)? Sanitizer.Sanitize(value): value;
            var encoded = (!column.Encode || string.IsNullOrEmpty(sanitized))
                ? sanitized
                : Nancy.Helpers.HttpUtility.HtmlEncode(sanitized);
            sb.Append(encoded);
        }

        public IGridHtmlOptions<T> Columns(Action<IGridColumnCollection<T>> columnBuilder)
        {
            _columnBuilder = columnBuilder;
            return this;
        }

        public IGridHtmlOptions<T> Sortable(bool enable)
        {
            // NotImplemented
            return this;
        }

        public IGridHtmlOptions<T> SetRowCssClasses(Func<T, string> contraint)
        {
            _rowClasses = contraint;
            return this;
        }

        public IGridColumnCollection<T> SetTableAttributes(object o)
        {
            throw new NotImplementedException();
        }

        private void RenderHeader(StringBuilder sb, GridColumnCollection<T> columns, bool asFooter)
        {
            var tag = asFooter
                ? "tfoot"
                : "thead";

            sb.AppendLine(string.Format($"<{tag}>"));
            sb.AppendLine("<tr>");
            foreach (var column in columns.GetColumns())
            {
                sb.Append("<th>");
                sb.Append(column.Title);
                sb.Append("</th>");
            }

            sb.AppendLine("</tr>");
            sb.AppendLine($"</{tag}>");
        }
    }
}