using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace K_Blog
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User_DAO user_query = new User_DAO();
            user_query.update_last_log_out(Convert.ToInt16(Session["user_id"]));

            Session.Abandon();
            Session["user_id"] = 0;
            Session["user_id"]=null;
            Response.Redirect("GuestHome.aspx", true);
        }
    }
}