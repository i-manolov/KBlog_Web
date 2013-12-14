using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace K_Blog
{
    public partial class UserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int user_id=Convert.ToInt16(Session["user_id"]);
                #region ColoRGV DataSource
                Media_DAO media_query = new Media_DAO();
                DataTable dt = media_query.recent_media("ColorSnapShot", user_id);

                colorGV.DataSource = dt;
                colorGV.DataBind();

                Media_DAO media_query2 = new Media_DAO();
                int csCount = media_query2.recent_media_count("ColorSnapshot", user_id);
                if (csCount == 0)
                {
                    // don't display
                    csBadge.Visible = false;
                }
                else
                {
                    // display that shit son!
                    csBadge.InnerText = csCount.ToString();
                }
                #endregion

                #region INFRARED DataSource
                Media_DAO media_query3 = new Media_DAO();
                DataTable dt2=media_query3.recent_media("InfraredSnapshot", user_id);
                infraredGV.DataSource = dt2;
                infraredGV.DataBind();

                Media_DAO media_query4 = new Media_DAO();
                int irCount = media_query4.recent_media_count("InfraredSnapshot", user_id);
                if (irCount == 0)
                {
                    // don't display
                    irBadge.Visible = false;
                }
                else
                {
                    // display that shit son!
                    irBadge.InnerText = irCount.ToString();
                }
                #endregion

                #region BlackAndWhite DataSource
                Media_DAO media_query5 = new Media_DAO();
                DataTable dt3 = media_query5.recent_media("BlackAndWhiteSnapshot", user_id);
                bwGV.DataSource = dt3;
                bwGV.DataBind();

                Media_DAO media_query6 = new Media_DAO();
                int bwCount = media_query6.recent_media_count("BlackAndWhiteSnapshot", user_id);
                if (bwCount == 0)
                {
                    // don't display
                    bwBadge.Visible = false;
                }
                else
                {
                    // display that shit son!
                    bwBadge.InnerText = bwCount.ToString();
                }
                #endregion

                #region Audio DataSource
                Media_DAO media_query7 = new Media_DAO();
                DataTable dt4 = media_query7.recent_media("AudioRecord", user_id);
                audioGV.DataSource = dt4;
                audioGV.DataBind();

                Media_DAO media_query8 = new Media_DAO();
                int audioCount = media_query8.recent_media_count("AudioRecord", user_id);
                if (audioCount == 0)
                {
                    // don't display
                    audioBadge.Visible = false;
                }
                else
                {
                    // display that shit son!
                    audioBadge.InnerText = audioCount.ToString();
                }
                #endregion
            }
        }

        protected void dateLinkCsBtn_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            string dir_path = lb.CommandArgument;
            var array = dir_path.Split('\\');
            string user_id= array[2] ;
            string media_type = array[3];
            string file_name = array[4];

            string app_k_blog_media_path = @"~/KBlog_Media";
            string image_src = app_k_blog_media_path + "/" + user_id + "/" + media_type + "/" + file_name;
            Session["file_path"] = image_src;

            previewImg.Src = image_src;
            previewImg.Visible = true;

            aliasFileNameBtn.Visible = true;
            aliasFileNameTxt.Visible = true;

        }

        protected void aliasFileNameBtn_Click(object sender, EventArgs e)
        {
            int user_id = Convert.ToInt16(Session["user_id"]);
            aliasFileNameBtn.Visible = false;
            aliasFileNameTxt.Visible = false;

            string file_path = Session["file_path"].ToString();
            string media_type=file_path.Split('/')[3];
            string file_name = file_path.Split('/')[4];
            string alias_file_name = aliasFileNameTxt.Text.Trim();
            Media_DAO media = new Media_DAO();
            media.update_alias_name(file_name, alias_file_name, Convert.ToInt16(Session["user_id"]));

            if (media_type=="ColorSnapshot")
            {
                Media_DAO media_query = new Media_DAO();
                DataTable dt = media_query.recent_media("ColorSnapShot", user_id);

                colorGV.DataSource = dt;
                colorGV.DataBind();
            }
            else if(media_type=="InfraredSnapshot")
            {
                 Media_DAO media_query3 = new Media_DAO();
                DataTable dt2=media_query3.recent_media("InfraredSnapshot", user_id);
                infraredGV.DataSource = dt2;
                infraredGV.DataBind();
            }
            else if(media_type=="BlackAndWhiteSnapshot")
            {
                 Media_DAO media_query5 = new Media_DAO();
                DataTable dt3 = media_query5.recent_media("BlackAndWhiteSnapshot", user_id);
                bwGV.DataSource = dt3;
                bwGV.DataBind();
            }
            else if (media_type == "Audio")
            {
                Media_DAO media_query7 = new Media_DAO();
                DataTable dt4 = media_query7.recent_media("AudioRecord", user_id);
                audioGV.DataSource = dt4;
                audioGV.DataBind();
            }
        }

        public void dateLinkAudioBtn_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            string dir_path = lb.CommandArgument;
            var array = dir_path.Split('\\');
            string user_id = array[2];
            string media_type = array[3];
            string file_name = array[4];

            string app_k_blog_media_path = @"/KBlog_Media";
            string audio_src = app_k_blog_media_path + "/" + user_id + "/" + media_type + "/" + file_name;
            Session["file_path"] = audio_src;

            divPreview.Controls.Clear();
            divPreview.Controls.Add(new LiteralControl("<audio src="+audio_src+ " type='audio/wav' controls autoplay ></audio>"));

            aliasFileNameBtn.Visible = true;
            aliasFileNameTxt.Visible = true;
        }
    }
}