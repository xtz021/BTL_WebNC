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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Hien_Users();
            
        }

        private void Hien_Users()
        {
            using (DataTable dt = getUsers())
            {
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
            int t = Convert.ToInt32(Session["NhomQuyen"].ToString());
            if (t != 1)
            {
                gvUsers.Columns[gvUsers.Columns.Count - 1].Visible = false;
                gvUsers.Columns[gvUsers.Columns.Count - 2].Visible = false;
            }
            gvUsers.DeleteRow(0);

        }

        private DataTable getUsers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select_Users_by_ID", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma", 0);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Equals("delete"))
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("delete_Users", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ma", ID);
                        cmd.ExecuteNonQuery();
                        Hien_Users();
                    }
                    cnn.Close();
                }

            }

        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        //protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
        //    using (SqlConnection cnn = new SqlConnection(connectionString))
        //    {
        //        cnn.Open();
        //        using (SqlCommand cmd = new SqlCommand("update_Users", cnn))
        //        {
        //            int t;
        //            CheckBox chB = gvUsers.Rows[e.RowIndex].FindControl("CheckBox1") as CheckBox;
        //            if (chB.Checked == true)
        //                t = 1;
        //            else
        //                t = 0;

        //            TextBox hoten = gvUsers.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
        //            TextBox ngaysinh = gvUsers.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@hoten", hoten.Text);
        //            cmd.Parameters.AddWithValue("@gt", t);
        //            cmd.Parameters.AddWithValue("@ns", ngaysinh.Text);
        //            cmd.Parameters.AddWithValue("@ma", Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value.ToString()));
        //            cmd.ExecuteNonQuery();
        //            Hien_Users();
        //        }
        //        cnn.Close();
        //    }
        //}
    }
}