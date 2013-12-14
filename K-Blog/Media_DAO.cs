using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;

namespace K_Blog
{
    public class Media_DAO
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public DataTable recent_media(string media_type, int user_id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("usp_get_recent_media", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@media_type", media_type);
            cmd.Parameters.AddWithValue("@user_id", user_id);

            using (con)
            {
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                ds.Tables[0].TableName = "Recent_Media";
            }
            return ds.Tables["Recent_Media"];
        }

        public int recent_media_count(string media_type, int user_id)
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("usp_get_recent_media_count", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.Parameters.AddWithValue("@media_type", media_type);

            using (con)
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    count = Convert.ToInt16(rdr["result"]);
                }
            }

            return count;
        }

        public void update_alias_name(string file_name, string alias_file_name, int user_id)
        {
            SqlCommand cmd = new SqlCommand("usp_update_alias_file_name", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.Parameters.AddWithValue("@file_name", file_name);
            cmd.Parameters.AddWithValue("@alias_file_name", alias_file_name);

            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void update_alias_name_by_id(int media_id, string alias_file_name, int user_id)
        {
            SqlCommand cmd = new SqlCommand("usp_update_alias_file_name_by_id", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", user_id);
            cmd.Parameters.AddWithValue("@media_id", media_id);
            cmd.Parameters.AddWithValue("@alias_file_name", alias_file_name);

            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable get_search_media(string alias_file_name, int media_type_id, string from_date_taken, string to_date_taken, int user_id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();


            SqlCommand cmd = new SqlCommand("usp_search_media", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@alias_file_name", alias_file_name);
            cmd.Parameters.AddWithValue("@media_type_id", media_type_id);
            cmd.Parameters.AddWithValue("@from_date_taken", from_date_taken);
            cmd.Parameters.AddWithValue("@to_date_taken", to_date_taken);
            cmd.Parameters.AddWithValue("@user_id", user_id);
            using (con)
            {
                con.Open();
                da.SelectCommand = cmd;
                da.Fill(ds);
                ds.Tables[0].TableName = "Search_Media";
            }

            foreach (DataRow row in ds.Tables["Search_Media"].Rows)
            {
                row["dir_path"] = row["dir_path"].ToString().Replace(@"\", @"\\");

            }

            return ds.Tables["Search_Media"];
        }



    }
}