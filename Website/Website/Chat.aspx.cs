﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDesign
{
    public partial class Chat : System.Web.UI.Page
    {
        Connection_C c;

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

            c = new Connection_C();
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
            HttpCookie cookie = new HttpCookie("UserName");
            cookie["Name"] = tbName.Text;
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);

            lbName.Text = cookie["Name"];
            MultiView.ActiveViewIndex = 1;
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            
                HttpCookie cookie = Request.Cookies["UserName"];

                TextBox chatText = TBMsg;
                string username = cookie["Name"];
                string chatInput = CheckIP();
                chatInput += "Chat=" + username + ": " + chatText.Text;
                chatText.Text = "";
                c.Send(chatInput);
        


        }

        protected void BtnLogOut_Click(object sender, EventArgs e)
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            MultiView.ActiveViewIndex = 0;
        }
    }
}