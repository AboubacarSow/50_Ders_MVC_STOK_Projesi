using System.Web;
using System.Web.Mvc;

namespace _50_Ders_MVC_Projesi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
