using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WebNC
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            check_Quyen();
        }

        //private void get_NhomQuyen()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
        //    using (SqlConnection cnn = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("select_unq_by_uID", cnn))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ma", Session["PK_iUserID"]);
        //            cnn.Open();
        //            cmd.ExecuteScalar();
        //            Session["NhomQuyen"] = cmd.ExecuteScalar().ToString();
        //            cnn.Close();
        //        }
        //    }
        //}

        private void check_Quyen()
        {
            //get_NhomQuyen();
            int x = Convert.ToInt32(Session["NhomQuyen"].ToString());
            if (x == 2)
            {
                Add_Edit_Articles.Visible = false;
            }
            else if (x == 3)
            {
                Users_List.Visible = false;
            }
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["PK_iUserID"] = 0;
            int a = Convert.ToInt32(Session["PK_iUserID"]);
            Response.Redirect("Login.aspx");
        }
    }
}