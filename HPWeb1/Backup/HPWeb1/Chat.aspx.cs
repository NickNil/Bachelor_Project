using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HPWeb1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            TextBox chatText = (TextBox)HeadLoginView.FindControl("TBMsg");
            string username = HeadLoginView.FindControl("HeadLoginName").Page.User.Identity.Name;
            string chatInput = username + ": " + chatText.Text;
        }
    }
}