
using Recaptcha;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Captcha
{
    public partial class GoogleReCaptcha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                lblResult.Text = "You Got It!";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                lblResult.Text = "Incorrect";
                lblResult.ForeColor = Color.Red;
            }
        }
    }
}