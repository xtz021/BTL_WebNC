using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//<asp:Label runat="server" Text='<%# (int) Eval("bDuyet") == 0 ? "chưa duyệt" : "đã duyệt" %>'></asp:Label>
namespace BTL_WebNC
{
    public partial class Articles_List : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Hien_Baiviet();
            labelx1.Text = "ID USER: " + Session["Pk_iuserid"].ToString();
            //if (Convert.ToInt32(Session["NhomQuyen"]) == 3)
            //{
            //    gv_Baiviet.Columns[gv_Baiviet.Columns.Count - 1].Visible = false;
            //    gv_Baiviet.Columns[gv_Baiviet.Columns.Count - 2].Visible id= false;
            //}
            Paging();
            if (Request.QueryString["command"] != null)
            {

                if (Request.QueryString["command"].Equals("2"))
                {
                    int ID = Int32.Parse(Request.QueryString["id"].ToString());
                    string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand("delete_Baibao", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ma", ID);
                            cmd.ExecuteNonQuery();
                            Hien_Baiviet();
                        }
                        cnn.Close();
                    }
                    Hien_Baiviet();

                }
            }
        }

        private void Hien_Baiviet()
        {
            using (DataTable dt = get_Baiviet())
            {
                gv_Baiviet.DataSource = dt;
                gv_Baiviet.DataBind();
            }
        }


        private DataTable get_Baiviet()
        {
            int quyen = Convert.ToInt32(Session["NhomQuyen"]);
            DataTable dt = new DataTable();
            if (quyen == 1)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select_Baibao_by_user", cnn))
                    {
                        int id = 0;
                        //if (Convert.ToInt32(Session["NhomQuyen"]) != 1 && Convert.ToInt32(Session["NhomQuyen"]) !=2)
                        //    //chi quyen 3 hoac 4 moi dc vao
                        //{
                        //    id = Convert.ToInt32(Session["PK_iUserID"]);
                        //}
                        id = Convert.ToInt32(Session["PK_iUserID"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ma", id);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                           
                            adapter.Fill(dt);
                           
                        }
                    }
                }
            }
            else
                if(quyen == 2)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select_Baibao_daduyet", cnn))
                    {
                        int id = 0;
                        //if (Convert.ToInt32(Session["NhomQuyen"]) != 1 && Convert.ToInt32(Session["NhomQuyen"]) !=2)
                        //    //chi quyen 3 hoac 4 moi dc vao
                        //{
                        //    id = Convert.ToInt32(Session["PK_iUserID"]);
                        //}
                      //  id = Convert.ToInt32(Session["PK_iUserID"]);
                        cmd.CommandType = CommandType.StoredProcedure;
                       // cmd.Parameters.AddWithValue("@ma", id);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            // dt = new DataTable();
                            adapter.Fill(dt);
                            
                        }
                    }
                }
            }
            return dt;
        }

        protected void gv_Baiviet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Equals("delete"))
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("delete_Baibao", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ma", ID);
                        cmd.ExecuteNonQuery();
                        Hien_Baiviet();
                    }
                    cnn.Close();
                }

            }
        }
        protected void gv_Baiviet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gv_Baiviet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Baiviet.PageIndex = e.NewPageIndex;
            gv_Baiviet.DataBind();
        }

        private void Paging()
        {

            #region page for repeater
            // Starting paging here.
            PagedDataSource pds = new PagedDataSource();
            DataView dt = get_Baiviet().DefaultView;

            pds.DataSource = dt;
            pds.AllowPaging = true;
            // Show number of product in one page.
            pds.PageSize = 4;
            // Specify sum of page.
            int numPage = pds.PageCount;
            int currentPage;
            if (Request.QueryString["page"] != null)
            {
                currentPage = Int32.Parse(Request.QueryString["page"]);
            }
            else
            {
                currentPage = 1;
            }
            // Because paging always start at 0.
            pds.CurrentPageIndex = currentPage - 1;
            // Show
            Label1.Text = "Page " + currentPage + " of " + pds.PageCount;
            // Config next - pre link.
            if (!pds.IsFirstPage)
            {
                lnkPre.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentPage - 1);
                lnkStart.NavigateUrl = Request.CurrentExecutionFilePath + "?page=1";
            }
            else
            {

                lnkPre.Visible = false;
            }
            if (!pds.IsLastPage)
            {
                lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + Convert.ToString(currentPage + 1);
                lnkEnd.NavigateUrl = Request.CurrentExecutionFilePath + "?page=" + numPage;
                lnkEnd.Text = numPage.ToString();
            }
            else
            {
                lnkEnd.Text = numPage.ToString();
                lnkNext.Visible = false;
            }
            if (numPage < 2)
            {
                Label1.Visible = false;
                lnkStart.Visible = false;
                lnkEnd.Visible = false;
            }
            #endregion

            gv_Baiviet.DataSource = pds;
            gv_Baiviet.DataBind();
        }
    }
}