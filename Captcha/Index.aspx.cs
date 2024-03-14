using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Captcha
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCaptcha();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["CaptchaCode"] != null && txtCaptcha.Text.Trim().ToLower() == Session["CaptchaCode"].ToString().ToLower())
            {
                lblMessage.Text = "CAPTCHA validation successful. Proceed with your action.";
                
            }
            else
            {
                lblMessage.Text = "CAPTCHA validation failed. Please try again.";
                GenerateCaptcha();
            }
        }

        private void GenerateCaptcha()
        {
            string captchaCode = GenerateRandomCodes(6); 
            Session["CaptchaCode"] = captchaCode.ToLower(); 
            imgCaptcha.ImageUrl = $"GenerateCaptcha.ashx?captchaCode={captchaCode}";
        }

        private string GenerateRandomCodes(int length)
        {
            // Method to generate a random code
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}