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
    public partial class Login : System.Web.UI.Page
    {
        int x = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbloi.Text = "";
        }

        private void check_Login()
        {
            string name = txtUsername.Text;
            string password = txtPass.Text;
            using (DataTable dt = get_Users())
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["sUserName"].ToString() == name)
                    {
                        x = 0;
                        if ((row["sUserName"].ToString() == name) && row["sPass"].ToString() != password)
                        {
                            x = 2;
                        }
                        if (x == 2)
                        {
                            Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                            lbloi.Text = "mật khẩu không chính xác.Vui lòng kiểm tra lại tài khoản và mật khẩu !";
                        }
                        else
                        {
                            Session["PK_iUserID"] = row["PK_iUserID"].ToString();
                            get_NhomQuyen();
                            int t = Convert.ToInt32(Session["NhomQuyen"].ToString());
                            if (t == 4 )
                            {
                                lbloi.Text = "Tài khoản không đủ quyền đăng nhập";
                                break;
                            }
                            Response.Redirect("Default.aspx");
                            break;
                        }
                    }
                }
                if (x == 1)
                {
                    Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                    lbloi.Text = "tài khoản không tồn tại";
                }
            }
        }

        private DataTable get_Users()
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

        private void get_NhomQuyen()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select_unq_by_uID", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma", Session["PK_iUserID"]);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Session["NhomQuyen"] =dt.Rows[0][1];
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            check_Login();
        }
    }
}