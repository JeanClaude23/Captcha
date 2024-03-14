using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Captcha
{
    public partial class GoogleReCaptchaV3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string responseToken = Request.Form["g-recaptcha-response"];
            (bool isHuman, float score) = ValidateCaptcha(responseToken);
            float threshold = 0.5f;
            if (isHuman && score >= threshold)
            {
                Response.Text = $"I am a Human (Score: {score})";
            }
            else
            {
                Response.Text = $"I am a Robot (Score: {score})";
            }

            //new CreateAssessmentSample().createAssessment();
        }

        private (bool, float) ValidateCaptcha(string responseToken)
        {
            string secretKey = "6LdIHoApAAAAAJLoDlzKQIao0Lxc_zQpigWV7NQb";
            string apiUrl = "https://www.google.com/recaptcha/api/siteverify";

            using (var client = new WebClient())
            {
                var postData = new System.Collections.Specialized.NameValueCollection
                {
                    { "secret", secretKey },
                    { "response", responseToken }
                };

                var response = client.UploadValues(apiUrl, postData);
                var jsonResponse = System.Text.Encoding.ASCII.GetString(response);

                var captchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(jsonResponse);

                return (captchaResponse.success, captchaResponse.score);
            }
        }

        public class RecaptchaResponse
        {
            public bool success { get; set; }
            public float score { get; set; } // Added score property
        }

    }
}