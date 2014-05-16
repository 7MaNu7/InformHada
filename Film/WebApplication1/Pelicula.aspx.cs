using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Pelicula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fondo.ImageUrl = "http://3.bp.blogspot.com/-tREmR3WN5LE/UwryZrZBKPI/AAAAAAAAu-s/E_UwmO8UvKM/s1600/divergente-banner.jpg";
            Video.Text = "F8nQnaJLV6M";
            caratula.ImageUrl = "http://s3-eu-west-1.amazonaws.com/abandomedia/db/foto/db_18973_41.jpg";
        }
    }
}