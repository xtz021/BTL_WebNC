using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WebNC
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Convert.ToInt32(Session["PK_iUserID"]) == 0)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}