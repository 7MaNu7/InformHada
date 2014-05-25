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


namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        public FilmBiblio.UsuarioEN usuarioLogeado = new FilmBiblio.UsuarioEN();
        private DataSet d = new DataSet();
        private FilmBiblio.PeliculaEN pelicula = new FilmBiblio.PeliculaEN();
        private FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            usuarioLogeado = (FilmBiblio.UsuarioEN)Session["usuario"];

            if (usuarioLogeado == null)
            {
                HyperLinkAnadirPelicula.Visible = false;
                HyperLinkAnadirSerie.Visible = false;
                HyperLinkUsuario.Visible = false;
                BotonCerrar.Visible = false;
            }
            else
            {
                HyperRegistro.Visible = false;
            }
            HyperRegistro.NavigateUrl = "Login.aspx";
            HyperLinkPeliculas.NavigateUrl = "Peliculas.aspx";
            HyperLinkSeries.NavigateUrl = "Series.aspx";
            HyperLinkUsuario.NavigateUrl = "Usuario.aspx";
            HyperLinkAnadirPelicula.NavigateUrl = "AddEditPelicula.aspx";
            HyperLinkAnadirSerie.NavigateUrl = "AddEditSerie.aspx";
            HyperLinkAbout.NavigateUrl = "About.aspx";
            HyperLinkReport.NavigateUrl = "Report.aspx";

            int numero = 10;

            if (!Page.IsPostBack)
            {
                d = pelicula.DamePeliculasRecientes(numero);
                ListViewRecientes.DataSource = d;
                ListViewRecientes.DataBind();

                d = serie.DameSeriesRecientes(numero);
                ListViewSrecientes.DataSource = d;
                ListViewSrecientes.DataBind();

                d = pelicula.DamePeliculasMejorPuntuadas(numero);
                ListViewPuntuadas.DataSource = d;
                ListViewPuntuadas.DataBind();

                d = serie.DameSeriesMejorPuntuadas(numero);
                ListViewSPuntuadas.DataSource = d;
                ListViewSPuntuadas.DataBind();
            }
        }

        protected void BotonBuscarOnClick(object sender, EventArgs e)
        {
            string texto = TextBoxBuscar.Text;
            Response.Redirect("ResultadosBusqueda.aspx?texto="+texto);
        }

        protected void CerrarOnClick(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}
