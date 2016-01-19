namespace ImgHttpHandlerWebForms.HttpHandlers
{
    using System.Drawing.Imaging;
    using System.Web;
    using Utilities;

    public class ImgHttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";

            var text = context.Request.Params["text"];
            if (text == null)
            {
                text = string.Empty;
            }

            var image = BitmapFromText.CreateBitmapImage(text);

            image.Save(context.Response.OutputStream, ImageFormat.Png);
        }

        public bool IsReusable { get { return false; } }
    }
}