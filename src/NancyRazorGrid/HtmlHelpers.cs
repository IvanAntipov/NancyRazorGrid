using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy.ViewEngines.Razor;

namespace NancyRazorGrid
{
    public static class HtmlHelpers
    {
        public static IGridHtmlOptions<T> Grid<T>(this Nancy.ViewEngines.Razor.HtmlHelpers helpers, IEnumerable<T> items)
        {
            return new HtmlGrid<T>(helpers, items);
        }
    }
}
