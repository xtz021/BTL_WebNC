using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;
using Newtonsoft.Json;

namespace BTL_WebNC
{
    public partial class Test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string sub(int num1, int num2)
        {
            IDictionary<string, int> dic = new Dictionary<string, int>();
            int subtotal = num1 - num2;
            dic.Add("data", subtotal);
            return JsonConvert.SerializeObject(dic, Formatting.Indented);
        }
    }
}