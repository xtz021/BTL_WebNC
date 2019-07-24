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
    public partial class FrontEnd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hien_Theloai();
            }
        }
        
        private void hien_Theloai()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select_Theloai_ByPK", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ma", 0);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        rptMenu.DataSource = dt;
                        rptMenu.DataBind();
                        rptMenuBottom.DataSource = dt;
                        rptMenuBottom.DataBind();
                    }
                }
            }
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["login"] = 0;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx?content="+txtSearch.Text);
        }

    }
}