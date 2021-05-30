using System.Web;
using System.Web.Mvc;

namespace gestion_riad_projet_fin_etude
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
