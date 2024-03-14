using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;

namespace Captcha
{
    public class GenerateCaptcha : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string captchaCode = context.Request.QueryString["captchaCode"];

                Random random = new Random();

                using (Bitmap bitmap = new Bitmap(200, 60))
                using (Graphics graphics = Graphics.FromImage(bitmap))
                using (Font font = new Font(new FontFamily("Arial"), random.Next(24, 36), FontStyle.Bold | FontStyle.Italic))
                using (LinearGradientBrush backgroundBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    Color.LightGray, Color.White, 45f))
                using (Pen noisePen = new Pen(Color.LightGray))
                using (SolidBrush noiseBrush = new SolidBrush(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256))))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    // Draw the background
                    graphics.FillRectangle(backgroundBrush, 0, 0, bitmap.Width, bitmap.Height);

                    // Draw the captcha code with random font, size, color, and distortion
                    for (int i = 0; i < captchaCode.Length; i++)
                    {
                        // Generate random rotation angle
                        float rotationAngle = (float)(random.NextDouble() * 60 - 30); // Random angle between -30 and 30 degrees

                        // Apply distortion using sine wave
                        PointF point = new PointF(i * 30 + random.Next(-5, 5), random.Next(0, 20));
                        float distortion = (float)(random.NextDouble() * 2 - 1) * 10; // Apply distortion using a sine wave
                        point.Y += distortion;

                        // Apply rotation and draw character
                        graphics.TranslateTransform(point.X, point.Y);
                        graphics.RotateTransform(rotationAngle);
                        graphics.DrawString(captchaCode[i].ToString(), font, noiseBrush, 0, 0);
                        graphics.ResetTransform();
                    }

                    // Apply random lines for noise
                    for (int i = 0; i < 6; i++)
                    {
                        int x1 = random.Next(bitmap.Width);
                        int y1 = random.Next(bitmap.Height);
                        int x2 = random.Next(bitmap.Width);
                        int y2 = random.Next(bitmap.Height);

                        graphics.DrawLine(noisePen, x1, y1, x2, y2);
                    }

                    // Apply random dots for noise
                    int density = 2000; // Density of noise points
                    for (int i = 0; i < bitmap.Width * bitmap.Height / density; i++)
                    {
                        int x = random.Next(bitmap.Width);
                        int y = random.Next(bitmap.Height);
                        int size = random.Next(1, 4);
                        Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                        graphics.FillEllipse(noiseBrush, x, y, size, size);
                    }

                    // Set content type and write image to response
                    context.Response.ContentType = "image/png";
                    bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                // Handle exception appropriately, e.g., log it or return an error response
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
