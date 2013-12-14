using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;


namespace K_Blog
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CheckEmail(object sender, EventArgs e)
        {
            User_DAO dao = new User_DAO();
            bool email_exists = dao.checkEmail(emailaddress.Text.Trim());
            if (email_exists == true)
            {
                emailExistsLbl.Visible = true;
                registerBtn.Enabled = false;
            }
            else 
            {
                emailExistsLbl.Visible = false;
                registerBtn.Enabled = true;
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            User_DAO dao = new User_DAO();
            string user_guid = dao.kinect_guid_login(firstname.Value.Trim(), lastname.Value.Trim(),
                emailaddress.Text.Trim(), password.Value.Trim(), Convert.ToBoolean(isprivatecb.Checked));

            successfull_login_div.Visible = true;
            kinectGUIDLbl.InnerText = user_guid;
            sign_up_div.Visible = false;
        }
    }
}