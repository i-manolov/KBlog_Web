using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace K_Blog
{
    public partial class Guest : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static void DirectoryCopy(
     string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }


            // Get the file contents of the directory to copy.
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                // Create the path to the new copy of the file.
                string temppath = Path.Combine(destDirName, file.Name);

                // Copy the file.
                if (Directory.Exists(temppath))
                {
                    // do nothing file has already been copied 
                }
                else
                {
                    file.CopyTo(temppath, false);
                }
            }

            // If copySubDirs is true, copy the subdirectories.
            if (copySubDirs)
            {

                foreach (DirectoryInfo subdir in dirs)
                {
                    // Create the subdirectory.
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    // Copy the subdirectories.
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);

                }
            }
        }

        private static void CopyDirectory(string sourcePath, string destPath)
        {
            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string dest = Path.Combine(destPath, Path.GetFileName(file));
                bool exists = File.Exists(dest);
                if (!exists)
                {
                File.Copy(file, dest);
                }
            }

            foreach (string folder in Directory.GetDirectories(sourcePath))
            {
                string dest = Path.Combine(destPath, Path.GetFileName(folder));
                CopyDirectory(folder, dest);
            }
        }

        protected void signInBtn_Click(object sender, EventArgs e)
        {
            User_DAO user = new User_DAO();
            int user_id = user.validate_login(emailTxt.Value.Trim(), passwordTxt.Value.Trim());
            if (user_id != 0)
            {
                //user does exist. Redirect
                Session["user_id"] = user_id;

                // need to copy files if they do not exist in application context folder KBlog_Media 
                string c_k_blog_media_path = @"C:\KBlog_Media";
                string c_k_blog_media_user = Path.Combine(c_k_blog_media_path, user_id.ToString());

                string app_k_blog_media_path = Server.MapPath(@"~/KBlog_Media");
                string app_k_blog_media_user = Path.Combine(app_k_blog_media_path, user_id.ToString());
                if (!Directory.Exists(app_k_blog_media_user))
                {
                    Directory.CreateDirectory(app_k_blog_media_user);
                }

                CopyDirectory(c_k_blog_media_user, app_k_blog_media_user);

                Response.Redirect("UserHome.aspx", true);



            }
            else
            {
                wrongLoginLbl.Visible = true;
            }
        }
    }
}