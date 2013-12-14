using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace K_Blog
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt16(Session["user_id"]) == 0 || Session["user_id"] == null)
            {
                Response.Redirect("GuestHome.aspx");
            }

            User_DAO user_query = new User_DAO();
            string user_full_name=user_query.return_user_full_name(Convert.ToInt16(Session["user_id"]));
            welcomeLbl.InnerText = user_full_name;
           
        }
    }
}