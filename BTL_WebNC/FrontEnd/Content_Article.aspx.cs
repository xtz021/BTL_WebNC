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
    public partial class Content_Article : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["tt"]);
            if (!IsPostBack)
            {
                hien_Article(id);
                update_solanXem(id);
            }
        }

        public void hien_Article(int id)
        {

            using (DataTable dt = get_Article_byid(id))
            {
                rptContent.DataSource = dt;
                rptContent.DataBind();
            }
        }

        public DataTable get_Article_byid(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select_Baibao", Cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma", id);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void update_solanXem(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("update_soluotxem", Cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma", id);
                    Cnn.Open();
                    cmd.ExecuteNonQuery();
                    Cnn.Close();
                }
            }
        }
    }
}