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
    public partial class Phan_Quyen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hien_Theloai();
            }
        }

        private DataTable get_Theloai()
        {
            string connect = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connect))
            {
                using (SqlCommand Cmd = new SqlCommand("select_nhomquyen_by_user", Cnn))
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

        private int get_Manhomquyen()
        {
            int id = Convert.ToInt32(Request.QueryString["tt"]);
            string connect = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connect))
            {
                using (SqlCommand Cmd = new SqlCommand("select_nhomquyen_by_user", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@ma", id);
                    Cnn.Open();
                    Cmd.ExecuteScalar();
                    int idnq = Convert.ToInt32(Cmd.ExecuteScalar());
                    Cnn.Close();
                    return idnq;
                }
            }
        }

        private void hien_Theloai()
        {
            using(DataTable dt = get_Theloai())
            {
                drdlPhanquyen.DataSource = dt;
                drdlPhanquyen.DataValueField = dt.Columns[0].ToString();
                drdlPhanquyen.DataTextField = dt.Columns[1].ToString();
                drdlPhanquyen.SelectedValue = get_Manhomquyen().ToString();
                drdlPhanquyen.DataBind();
            }
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["tt"]);
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("update_User_nhomquyen", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@mauser", id);
                    Cmd.Parameters.AddWithValue("@manq", get_Manhomquyen().ToString());
                    Cmd.Parameters.AddWithValue("@manqm", drdlPhanquyen.SelectedValue.ToString());
                    Cnn.Open();
                    Cmd.ExecuteNonQuery();
                    Cnn.Close();

                }

            }
            Response.Redirect("Users.aspx");
        }
    }
}