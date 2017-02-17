using System.Web;
using DemoArps_Models;

namespace DemoArps_Utils
{
    public class SessionHelper
    {
        public static ArpsAward ArpsAward
        {
            get
            {
                return HttpContext.Current.Session["WFData"] as ArpsAward;
            }

            set
            {
                HttpContext.Current.Session["WFData"] = value;
            }
        }
    }
}