using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication10
{
    public partial class _Default : Page
    {
        static int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Request.IsAuthenticated)
            //{
            //    if (i % 2 == 0)
            //    {
            //        HttpContext.Current.GetOwinContext().Authentication.Challenge(
            //          new AuthenticationProperties { RedirectUri = "/" },
            //          "extranet_sunchemical");
            //    }
            //    else
            //    {
            //        HttpContext.Current.GetOwinContext().Authentication.Challenge(
            //          new AuthenticationProperties { RedirectUri = "/" },
            //          "sunchemical");
            //    }
            //    i++;
            //}
        }
    }
}