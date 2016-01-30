using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;

namespace AnySystem.Web.Account
{
    using Data.Models;

    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var user = new User()
            {
                UserName = Email.Text,
                Email = Email.Text,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                ProfileImageUrl = ProfileImageUrl.Text ?? "http://donatered-asset.s3.amazonaws.com/assets/default/default_user-884fcb1a70325256218e78500533affb.jpg",
                FacebookUrl = FacebookUrl.Text ?? "http://facebook.com/",
                YoutubeUrl = YoutubeUrl.Text ?? "http://youtube.com/"
            };

            IdentityResult result = manager.Create(user, Password.Text);

            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);

                // as per the exam description -> redirect to home
                Response.Redirect("~/");

                // IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}