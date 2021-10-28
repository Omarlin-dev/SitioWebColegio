using System.Web;
using System.Web.Mvc;
using SitioWebColegio.Filtro;

namespace SitioWebColegio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
