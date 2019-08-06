using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Web.Routing;
using System.Web.Script.Services;
using System.Web.Services;





namespace BTL_WebNC
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Hien_Users();
            if (Request.QueryString["k"] != null)
            {
                if (Request.QueryString["k"].Equals("1"))
                {
                    Response.Write("okkkk");
                }
            }

            Response.Write("okk11111111");

        }

        private void Hien_Users()
        {
            using (DataTable dt = getUsers())
            {
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
            //int t = Convert.ToInt32(Session["NhomQuyen"].ToString());
            //if (t != 1)
            //{
            //    gvUsers.Columns[gvUsers.Columns.Count - 1].Visible = false;
            //    gvUsers.Columns[gvUsers.Columns.Count - 2].Visible = false;
            //}
            gvUsers.DeleteRow(0);

        }

        private DataTable getUsers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select_All_Users", cnn))
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
        [WebMethod]
        public static string getUser1() =>


          /* string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
           using (SqlConnection cnn = new SqlConnection(connectionString))
           {
               using (SqlCommand cmd = new SqlCommand("select_All_Users", cnn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@ma", 0);
                   using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                   {
                       DataTable dt = new DataTable();
                       adapter.Fill(dt);
                       //return dt;
                       var result = JsonConvert.SerializeObject(dt);
                      // return "result";
                   }
               }
           }*/
          (string)"huydxz";/// <summary>
          /// /
          /// </summary>
          /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string getUser2()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
           // int total = num1 + num2;
            dic.Add("data", 5);
            return JsonConvert.SerializeObject(dic, Formatting.Indented);
        }
        [WebMethod]
        public static bool Insert()
        {
            return false;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public static string add(int num1, int num2)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int total = num1 + num2;
            dic.Add("data", total);
            return JsonConvert.SerializeObject(dic, Formatting.Indented);
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower().Equals("delete"))
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("delete_Users", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ma", ID);
                        cmd.ExecuteNonQuery();
                        Hien_Users();
                    }
                    cnn.Close();
                }

            }

        }
        [WebMethod]
        public static string Testajax()
           
        {
            String sCnStr = @"Data Source=DESKTOP-69BHUF7\SQLEXPRESS;Initial Catalog=thuHanh;Integrated Security=True";
           
             Random rd = new Random();
             int x = rd.Next(1, 1000);
            using (SqlConnection sCnn = new SqlConnection(sCnStr))
            {
                sCnn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "DanhGia";
                    cmd.Connection = sCnn;
                    cmd.Parameters.Add(new SqlParameter("@idLaixe", 4));
                    cmd.Parameters.Add(new SqlParameter("@dNgaydanhgia", "02/02/2015"));
                    cmd.Parameters.Add(new SqlParameter("@iSosao", 4));
                    cmd.Parameters.Add(new SqlParameter("@id", x));
                    int kq = cmd.ExecuteNonQuery();
                    if (kq != 0)
                    {
                        return "ok roi";
                    }
                    return "false";
                }
            }
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        //protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["BDT"].ConnectionString;
        //    using (SqlConnection cnn = new SqlConnection(connectionString))
        //    {
        //        cnn.Open();
        //        using (SqlCommand cmd = new SqlCommand("update_Users", cnn))
        //        {
        //            int t;
        //            CheckBox chB = gvUsers.Rows[e.RowIndex].FindControl("CheckBox1") as CheckBox;
        //            if (chB.Checked == true)
        //                t = 1;
        //            else
        //                t = 0;

        //            TextBox hoten = gvUsers.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
        //            TextBox ngaysinh = gvUsers.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@hoten", hoten.Text);
        //            cmd.Parameters.AddWithValue("@gt", t);
        //            cmd.Parameters.AddWithValue("@ns", ngaysinh.Text);
        //            cmd.Parameters.AddWithValue("@ma", Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value.ToString()));
        //            cmd.ExecuteNonQuery();
        //            Hien_Users();
        //        }
        //        cnn.Close();
        //    }
        //}
    }
}