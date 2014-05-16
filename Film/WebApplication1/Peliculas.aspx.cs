using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Peliculas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

<<<<<<< HEAD
            if (!Page.IsPostBack)
            {
                d = pelicula.DamePeliculas();
                ListViewPeliculas.DataSource = d;
                ListViewPeliculas.DataBind();
            }
=======
>>>>>>> b4de745d152f3feb4ac7a2b93a51b618b36225da
        }
    }
}