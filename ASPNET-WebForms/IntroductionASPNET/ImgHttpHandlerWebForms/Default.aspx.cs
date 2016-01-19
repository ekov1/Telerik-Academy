using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ImgHttpHandlerWebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getImage_OnServerClick(object sender, EventArgs e)
        {
            var resultImage = this.resultImage;
            //var text = this.textInput;
            resultImage.ImageUrl = "getImage.img?text=" + HttpContext.Current.Server.UrlEncode("Pesho");
        }
    }
}