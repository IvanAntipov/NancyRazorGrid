using System;
using System.Linq.Expressions;

namespace NancyRazorGrid
{
    public class Column<T> : IColumn<T>
    {
        public string Title { get; private set; }
        public bool Sanitize { get; private set; }
        public string CssClasses { get; private set; }
        public Func<T, string> Renderer { get; private set; }
        public bool Encode { get; private set; }
        public readonly string _memberName;

        public Column(string memberName)
        {
            _memberName = memberName;
            Title = _memberName;
            Sanitize = true;
            CssClasses = null;
            Renderer = DefaultRenderAs;
            Encode = true;
        }

        public IColumn<T> Titled(string title)
        {
            Title = title;
            return this;
        }

        public IColumn<T> Encoded(bool encode)
        {
            Encode = encode;
            return this;

        }

        public IColumn<T> Sanitized(bool sanitize)
        {
            Sanitize = sanitize;
            return this;
        }

        public IColumn<T> SetWidth(string width)
        {
            //TODO implement
            return this;
        }

        public IColumn<T> SetWidth(int width)
        {
            //TODO implement
            return this;

        }

        public IColumn<T> Css(string cssClasses)
        {
            CssClasses = cssClasses;
            return this;
        }

        public IColumn<T> RenderValueAs(Func<T, string> renderAs)
        {
            Renderer = renderAs;
            return this;
        }

        public IColumn<T> Format(string pattern)
        {
            throw new NotImplementedException();
        }

        public IColumn<T> Sortable(bool sort)
        {
            // TODO implement
            return this;
        }

        private static string DefaultRenderAs(T val)
        {
            return val?.ToString() ?? "";
        }
    }
}