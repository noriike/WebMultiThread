using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMultiThread.Logic;
using System.Runtime.Remoting.Messaging;
namespace WebMultiThread.Forms
{
    public partial class WebForm1 : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DoWork();
        }

        private void DoWork()
        {
            lblStart.Text = DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss.fff");
            ReadData r = new ReadData();

            List<long> result = r.DoWorkAsync();

            GridView1.DataSource = result.Take(100);
            GridView1.DataBind(); 
            
            lblEnd.Text = DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss.fff");

        }
    }
}