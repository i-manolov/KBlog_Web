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
    public class User_DAO
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public Boolean checkEmail(string email)
        {
            bool result=false;
            using (con)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_CheckEmail", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //Create PROCEDURE [dbo].[usp_CheckEmail]
                //(
                //@Email varchar (50)
                //)
                //AS
                //BEGIN
                //    if exists (Select * from Users where Email= @Email )
                //        Select 1 as ReturnCode
                //    else
                //        Select 0 as ReturnCode
                //END

                cmd.Parameters.AddWithValue("@Email", email);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (Convert.ToBoolean(rdr["ReturnCode"]))
                    {
                        result= true;
                    }
                    else
                    {
                        result= false;
                    }
                }
                con.Close();
            }
            return result;
        }

        public string Get8Digits()
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }

        public string kinect_guid_login(string first_name, string last_name,
            string email, string password, bool is_private)
        {

            string user_guid = Get8Digits();

 

            using (con)
            {
                con.Open();
                SqlCommand cmd=new SqlCommand("usp_InsertUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                // CREATE PROCEDURE usp_InsertUser
                //@First_Name varchar (50),
                //@Last_Name varchar(50),
                //@Email varchar (50),
                //@Password varchar(50),
                //@user_guid varchar(50),
                //@is_private bit
                //AS
                //BEGIN
                //    INSERT INTO Users (First_Name,Last_Name, Email, Password, user_guid, is_private)  VALUES 
                //        (@First_Name, @Last_Name, @Email,@Password, @user_guid, @is_private)
                //END

                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@user_guid", user_guid);
                cmd.Parameters.AddWithValue("@is_private", is_private);
                cmd.ExecuteNonQuery();

                return user_guid;
            }
        }

        public int validate_login(string email, string password)
        {
            Int16 user_id=0;
            SqlCommand cmd = new SqlCommand("usp_validate_login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            //Create Procedure usp_validate_login
            //@email varchar(80),
            //@password varchar(80)
            //AS
            //BEGIN
            //    if exists (select * from Users where email= @email and password=@password)
            //    BEGIN	
            //            select user_id from users where email=@email and password=@password
            //    END
            //    ELSE
            //    BEGIN
            //        Select 0 as user_id
            //    END
            //END
            using (con)
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    user_id = Convert.ToInt16(rdr["user_id"]);
                }
            }

            return user_id;
        }

        public string return_user_full_name(int user_id)
        {
            Types.User user = new Types.User();
            string user_full_name = "";
            SqlCommand cmd = new SqlCommand("usp_get_user_information", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //Create procedure usp_get_user_full_name
            //@user_id bigint
            //AS
            //BEGIN
            //    Select * Users where user_id=@user_id
            //END
            cmd.Parameters.AddWithValue("@user_id", user_id);
            using (con)
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    user.FirstName = rdr["first_name"].ToString();
                    user.LastName = rdr["last_name"].ToString();
                }
            }
            user_full_name = user.FirstName + " "+ user.LastName;
            return user_full_name;
        }

        public void update_last_log_out(int user_id)
        {
            SqlCommand cmd = new SqlCommand("usp_update_last_log_out", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //create procedure usp_update_last_log_out
            //@user_id bigint
            //AS
            //BEGIN
            //    Update Users set last_sign_out=getdate() where user_id=@user_id
            //END
            cmd.Parameters.AddWithValue("@user_id", user_id);
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}