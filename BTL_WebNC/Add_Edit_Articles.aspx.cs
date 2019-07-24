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
    public partial class Add_Edit_Articles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            int kind = Convert.ToInt32(Request.QueryString["kind"]);
            if (kind == 1)
            {
                get_Theloai();
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["tt"]);
                if (!IsPostBack)
                {
                    hienArticle(id);
                    get_Theloai();
                }
                if (kind == 3)
                {
                    btnAdd.Visible = false;
                    btnDuyet.Visible = true;
                    flAnhDaidien.Visible = false;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int kind = Convert.ToInt32(Request.QueryString["kind"]);
            if (kind == 1)
            {
                if (flAnhDaidien.FileContent.Length > 0)
                {
                    if (flAnhDaidien.FileName.EndsWith(".jpeg") || flAnhDaidien.FileName.EndsWith(".jpg") || flAnhDaidien.FileName.EndsWith(".png"))
                    {
                        flAnhDaidien.SaveAs(Server.MapPath("images/" + flAnhDaidien.FileName));
                        string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("insert_Baibao", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@tieude", txtTieude.Text);
                        Cmd.Parameters.AddWithValue("@mota", txtMota.Text);
                        Cmd.Parameters.AddWithValue("@noidung", txtNoidung.Text);
                        Cmd.Parameters.AddWithValue("@ngaydang", DateTime.Now);
                        Cmd.Parameters.AddWithValue("@manguoidang", Session["PK_iUserID"]);
                        Cmd.Parameters.AddWithValue("@matl", cboTheloai.SelectedValue.ToString());
                        Cmd.Parameters.AddWithValue("@urlanh", "images/" + flAnhDaidien.FileName);
                        Cnn.Open();
                        Cmd.ExecuteNonQuery();
                        Cnn.Close();

                    }

                }
                    }
                }
                
            }
            else
            {
                int id = Convert.ToInt32(Request.QueryString["tt"]);


                if (flAnhDaidien.FileContent.Length >0)
                {
                    if (flAnhDaidien.FileName.EndsWith(".jpeg") || flAnhDaidien.FileName.EndsWith(".jpg") || flAnhDaidien.FileName.EndsWith(".png"))
                    {
                        flAnhDaidien.SaveAs(Server.MapPath("images/" + flAnhDaidien.FileName));
                        string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                        using (SqlConnection Cnn = new SqlConnection(connectionString))
                        {
                            using (SqlCommand Cmd = new SqlCommand("update_Baibao", Cnn))
                            {
                                Cmd.CommandType = CommandType.StoredProcedure;
                                Cmd.Parameters.AddWithValue("@tieude", txtTieude.Text);
                                Cmd.Parameters.AddWithValue("@noidung", txtNoidung.Text);
                                Cmd.Parameters.AddWithValue("@matl", cboTheloai.SelectedValue.ToString());
                                Cmd.Parameters.AddWithValue("@mota", txtMota.Text);
                                Cmd.Parameters.AddWithValue("@urlanh", "images/" + flAnhDaidien.FileName);
                                Cmd.Parameters.AddWithValue("@ma", id);
                                Cnn.Open();
                                Cmd.ExecuteNonQuery();
                                Cnn.Close();

                            }

                        }
                    }
                }
                else
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                    using (SqlConnection Cnn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand Cmd = new SqlCommand("update_Baibao2", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.Parameters.AddWithValue("@tieude", txtTieude.Text);
                            Cmd.Parameters.AddWithValue("@noidung", txtNoidung.Text);
                            Cmd.Parameters.AddWithValue("@matl", cboTheloai.SelectedValue.ToString());
                            Cmd.Parameters.AddWithValue("@mota", txtMota.Text);
                            Cmd.Parameters.AddWithValue("@ma", id);
                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();

                        }

                    }
                }
            }
            Response.Redirect("Articles_List.aspx");
        }

        private void get_Theloai()
        {
            string connect = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connect))
            {
                using (SqlCommand Cmd = new SqlCommand("select_Theloai_ByPK", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@ma", 0);
                    using (SqlDataAdapter da = new SqlDataAdapter(Cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cboTheloai.DataSource = dt;
                        cboTheloai.DataValueField = dt.Columns[0].ToString();
                        cboTheloai.DataTextField = dt.Columns[1].ToString();
                        cboTheloai.DataBind();
                    }
                }
            }
        }

        private void hienArticle(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select_Baibao", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma", id);
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.HasRows && rd.Read())
                        {
                            txtTieude.Text = rd["sTieude"].ToString();
                            txtNoidung.Text = rd["sNoidung"].ToString();
                            txtMota.Text = rd["sMota"].ToString();
                            cboTheloai.DataValueField = rd["sTenTheloai"].ToString();
                            btnAdd.CommandArgument = id.ToString();
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
        }

        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["tt"]);
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("duyet_Baibao", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@ma", id);
                    Cnn.Open();
                    Cmd.ExecuteNonQuery();
                    Cnn.Close();

                }

            }
            Response.Redirect("Articles_List.aspx");
        }
    }
}