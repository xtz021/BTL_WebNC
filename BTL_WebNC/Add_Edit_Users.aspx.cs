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
    public partial class Add_Edit_Users1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int kind = Convert.ToInt32(Request.QueryString["kind"]);
            if (kind == 2)
            {
                int id = Convert.ToInt32(Request.QueryString["tt"]);
                if (!IsPostBack)
                {
                    hienUser(id);
                    txtUsername.Visible = false;
                    txtPass.Visible = false;
                    lbUser.Visible = lbPass.Visible = false;
                }
            }
            getQuyen();
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

            int kind = Convert.ToInt32(Request.QueryString["kind"]);
            if (kind == 1)
            {
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
                            Cmd.Parameters.AddWithValue("@quyen", quyenCbb.SelectedValue.ToString());
                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();

                        }

                    }
                }
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["tt"]);
                string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("update_Users", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@hoten", hoten);
                        Cmd.Parameters.AddWithValue("@gt", gioitinh);
                        Cmd.Parameters.AddWithValue("@ns", ngaysinh);
                        Cmd.Parameters.AddWithValue("@ma", id);
                        Cmd.Parameters.AddWithValue("@quyen", quyenCbb.SelectedValue.ToString());

                        Cnn.Open();
                        Cmd.ExecuteNonQuery();
                        Cnn.Close();

                    }
                }
            }

            Session["login"] = 1;
            Response.Redirect("Users.aspx");

        }
        private void getQuyen()
        {
            string connect = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connect))
            {
                using (SqlCommand Cmd = new SqlCommand("select_quyen", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                   // Cmd.Parameters.AddWithValue("@ma", 0);
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        quyenCbb.DataSource = dt;
                        
                        quyenCbb.DataTextField = dt.Columns[1].ToString();
                        quyenCbb.DataValueField = dt.Columns[0].ToString();
                        quyenCbb.DataBind();
                    }
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

        private void hienUser(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select_Users_by_ID", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma", id);
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows && rd.Read())
                        {
                            txtUsername.Text = rd["sUserName"].ToString();
                            txtPass.Text = rd["sPass"].ToString();
                            txtHoten.Text = rd["sHoten"].ToString();
                            txtNgaysinh.Text = rd["dNgaysinh"].ToString();
                            if (rd["bGioitinh"].ToString().Equals("True"))
                                rbtnam.Checked = true;
                            else rbtnu.Checked = true;
                            btnAdd.CommandArgument = id.ToString();
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
        }
    }
}