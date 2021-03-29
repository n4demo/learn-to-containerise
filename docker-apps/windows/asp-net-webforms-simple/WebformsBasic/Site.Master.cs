using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WingtipToys
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

                protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
        }
    }

}