using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class Peliculas : System.Web.UI.Page
    {
        private DataSet d=new DataSet();
        private FilmBiblio.PeliculaEN pelicula=new FilmBiblio.PeliculaEN();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLinkAddPelicula.NavigateUrl = "AddEditPelicula.aspx";

            if (Session["usuario"] == null)
                HyperLinkAddPelicula.Visible = false;

            if (!Page.IsPostBack)
            {
                d = pelicula.DamePeliculas();
                ListViewPeliculas.DataSource = d;
                ListViewPeliculas.DataBind();

              
            }
        }

        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            d = pelicula.DamePeliculas();
            ListViewPeliculas.DataSource = d;
            ListViewPeliculas.DataBind();
        }
    }
}