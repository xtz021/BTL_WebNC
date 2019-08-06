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
    public partial class KindArticle : System.Web.UI.Page
    {
        public int id;
        protected void Page_Load(object sender, EventArgs e)
        {
           
                id = Convert.ToInt32(Request.QueryString["tt"]);
                DataTable dt1 = get_table_news();
                rptNews.DataSource = dt1;
                rptNews.DataBind();

                Paging();






                //get_Newest_Article();
            
        }

        private DataTable get_table_news()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select_Baibao_by_Theloai", cnn))
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

        private void get_Newest_Article()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select_Baibao_daduyet_newsest", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        DataView dv = dt.DefaultView;
                        dv.Sort = "PK_iBaivietID desc";
                        DataTable sortedDT = dv.ToTable();
                        rptNewestArticle.DataSource = sortedDT;
                        rptNewestArticle.DataBind();
                        int icount = rptNewestArticle.Items.Count;
                        if (icount > 5)
                        {
                            for (int i = 5; i < icount; i++)
                            {
                                rptNewestArticle.Items[i].Visible = false;
                            }
                        }
                    }
                }
            }
        }
        public void Paging()
        {

            #region page for repeater
            // Starting paging here.
            PagedDataSource pds = new PagedDataSource();
            DataView dt = get_table_news().DefaultView;

            pds.DataSource = dt;
            pds.AllowPaging = true;
            // Show number of product in one page.
            pds.PageSize = 3;
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
            Label1.Text = currentPage.ToString();//"(  Trang " + currentPage + " của " + pds.PageCount+")";
            // Config next - pre link.
            if (!pds.IsFirstPage)
            {
                lnkPre.NavigateUrl = Request.CurrentExecutionFilePath + "?tt=" + id + "&page=" + Convert.ToString(currentPage - 1);
                lnkStart.NavigateUrl = Request.CurrentExecutionFilePath + "?tt=" + id + "&page=";
            }
            else
            {

                lnkPre.Visible = false;
            }
            if (!pds.IsLastPage)
            {
                lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?tt="+id+"&page=" + Convert.ToString(currentPage + 1);
                lnkEnd.NavigateUrl = Request.CurrentExecutionFilePath + "?tt=" + id + "&page=" + numPage;
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

            rptNews.DataSource = pds;
            rptNews.DataBind();
        }
    }
}