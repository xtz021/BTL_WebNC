using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_WebNC.FrontEnd
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            check_Login();
        }

        private void check_Login()
        {
            int x = 1;
            string t;
            string name = txtUsername.Text;
            string password = txtPass.Text;
            using (DataTable dt = get_Users())
            {
                foreach (DataRow row in dt.Rows)
                {
                    t = row["sUserName"].ToString();
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
                            break;
                        }
                        else
                        {
                            Session["login"] = 1;
                            Response.Redirect("TrangChu.aspx");
                        }
                    }

                    if (x == 1)
                    {
                        Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                        lbloi.Text = "tài khoản không tồn tại";
                        Response.Redirect("TrangChu.aspx");
                    }
                }                    
            }
        }

        private DataTable get_Users()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select_Users_by_ID1", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@ma", 0);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}