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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            int x = 0;
            string username = txtUsername.Text;
            string pass = txtPass.Text;
            string hoten = txtHoten.Text;
            string ngaysinh = txtNgaysinh.Text;
            int gioitinh = 0;
            if (rbtnam.Checked)
                gioitinh = 1;
            else gioitinh = 0;

            using (DataTable dt = get_danhsach_User())
            {
                foreach (DataRow row in dt.Rows)
                {
                    if ((row["sUserName"].ToString() == username))
                    {
                        x = 1;
                        break;
                    }
                }
            }
            if (x == 1)
            {
                lbloi.Text = "Tên đăng nhập đã tồn tại. Vui long nhập lại !";
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("insert_Users", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@username", username);
                        Cmd.Parameters.AddWithValue("@pass", pass);
                        Cmd.Parameters.AddWithValue("@hoten", hoten);
                        Cmd.Parameters.AddWithValue("@gt", gioitinh);
                        Cmd.Parameters.AddWithValue("@ns", ngaysinh);
                        Cnn.Open();
                        Cmd.ExecuteNonQuery();
                        Cnn.Close();

                    }
                    Session["login"] = 1;
                    Response.Redirect("TrangChu.aspx");
                }
            }
        }
        private DataTable get_danhsach_User()
        {
            string connect = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connect))
            {
                using (SqlCommand Cmd = new SqlCommand("select_Users_by_ID", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@ma", 0);
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}