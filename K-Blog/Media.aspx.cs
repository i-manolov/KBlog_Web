using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace K_Blog
{
    public partial class Media : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Media_DAO media_query = new Media_DAO();
                searchGV.DataSource = media_query.get_search_media(alias_file_name_txt.Text.Trim(), Convert.ToInt16(mediaTypeDDL.SelectedValue),
                        from_date_txt.Text.Trim(), to_date_txt.Text.Trim(), Convert.ToInt16(Session["user_id"]));
                searchGV.DataBind();
            }

        }

        protected void searchGV_RowEditing(object sender, GridViewEditEventArgs e)
        {
            searchGV.EditIndex = e.NewEditIndex;
            FillGrid();
        }
        protected void searchGV_RowCancelingEdit(object sender,
                                  GridViewCancelEditEventArgs e)
        {
            searchGV.EditIndex = -1;
            FillGrid();
        }

        public void FillGrid()
        {
            Media_DAO media_query = new Media_DAO();
            searchGV.DataSource = media_query.get_search_media(alias_file_name_txt.Text.Trim(), Convert.ToInt16(mediaTypeDDL.SelectedValue),
                    from_date_txt.Text.Trim(), to_date_txt.Text.Trim(), Convert.ToInt16(Session["user_id"]));
            searchGV.DataBind();
        }

        protected void searchGV_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = searchGV.EditIndex;
            GridViewRow row = searchGV.Rows[index];
            TextBox t1 = row.FindControl("updateAliasTxt") as TextBox;
            string test = t1.Text;
            TextBox new_alias = (TextBox)searchGV.Rows[e.RowIndex].FindControl("updateAliasTxt");
            int media_id = Convert.ToInt16(searchGV.DataKeys[e.RowIndex]["media_id"]);

            Media_DAO media_query2 = new Media_DAO();
            media_query2.update_alias_name_by_id(media_id, new_alias.Text.Trim(), Convert.ToInt16(Session["user_id"]));
            searchGV.EditIndex = -1;
            FillGrid();
        }

        public void searchBtn_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

    }
}