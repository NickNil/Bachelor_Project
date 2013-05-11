using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDesign
{
    public partial class Chat : System.Web.UI.Page
    {
        TCP_Client c;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Cookies["UserName"] != null)
            {
                HttpCookie cookie = Request.Cookies["UserName"];
                MultiView.ActiveViewIndex = 1;
                lbName.Text = cookie["Name"];
            }
            else
                MultiView.ActiveViewIndex = 0;

            c = new TCP_Client();
        }

        protected string CheckIP()
        {
            String ip =
                HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ("IP=[" + ip + "]");
        }

        protected void btnSaveToCookie_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Contains(" ") || tbName.Text.Length > 15)
            {
                LbError.Text = "Ugyldig brukernavn. Bruker navnet skal ikke inneholder mellomrom og har maks 15 tegn";
            }
            else
            {
                HttpCookie cookie = new HttpCookie("UserName");
                cookie["Name"] = tbName.Text;
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);

                lbName.Text = cookie["Name"];
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            if (TBMsg.Text.Length > 30)
            {
                LbError.Text = "Melding skal maks ha 30 tegn";
            }
            else
            {
                HttpCookie cookie = Request.Cookies["UserName"];

                TextBox chatText = TBMsg;
                string username = cookie["Name"];
                string chatInput = CheckIP();
                chatInput += "Chat=" + username + ": " + chatText.Text;
                chatText.Text = "";
                c.Send(chatInput);
            }


        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}