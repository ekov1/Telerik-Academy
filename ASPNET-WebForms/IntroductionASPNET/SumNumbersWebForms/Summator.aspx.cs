namespace SumNumbersWebForms
{
    using System;

    public partial class Summator : System.Web.UI.Page
    {
        protected void sum_OnServerClick(object sender, EventArgs e)
        {
            var a = int.Parse(this.numA.Value);
            var b = int.Parse(this.numB.Value);

            var label = this.result;
            label.Text = (a + b).ToString();
        }
    }
}