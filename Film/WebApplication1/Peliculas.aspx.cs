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
            //si pulsas en añadir pelicula te manda a añadir una
            HyperLinkAddPelicula.NavigateUrl = "AddEditPelicula.aspx";

            //para poder añadir una pelicula tienes que logearte
            if (Session["usuario"] == null)
                HyperLinkAddPelicula.Visible = false;

            if (!Page.IsPostBack)
            {
                //mostrar en formato listview las peliculas de la bd
                d = pelicula.DamePeliculas();
                ListViewPeliculas.DataSource = d;
                ListViewPeliculas.DataBind();

              
            }
        }
        //metodo para paginar el listview de las peliculas
        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            d = pelicula.DamePeliculas();
            ListViewPeliculas.DataSource = d;
            ListViewPeliculas.DataBind();
        }
    }
}