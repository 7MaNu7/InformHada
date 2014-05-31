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

            //si no estas logeado no puedes acceder a la parte privada
            if (usuarioLogeado == null)
            {
                HyperLinkAnadirPelicula.Visible = false;
                HyperLinkAnadirSerie.Visible = false;
                HyperLinkUsuario.Visible = false;

                //no puedes cerrar sesion si no has iniciado antes
                BotonCerrar.Visible = false;
            }
            else
            {
                //si no estas logeado sale la opcion de iniciar/registrarse
                HyperRegistro.Visible = false;
            }

            //paginas a las que te llevan los link del menu
            HyperRegistro.NavigateUrl = "Login.aspx";
            HyperLinkPeliculas.NavigateUrl = "Peliculas.aspx";
            HyperLinkSeries.NavigateUrl = "Series.aspx";
            HyperLinkUsuario.NavigateUrl = "Usuario.aspx";
            HyperLinkAnadirPelicula.NavigateUrl = "AddEditPelicula.aspx";
            HyperLinkAnadirSerie.NavigateUrl = "AddEditSerie.aspx";
            HyperLinkAbout.NavigateUrl = "About.aspx";
            HyperLinkReport.NavigateUrl = "Report.aspx";

            //cantidad resumen de peliculas y series que se sacan en los listview siguientes
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

        //cuando buscamos en la barra
        protected void BotonBuscarOnClick(object sender, EventArgs e)
        {
            //te lleva a la pagina de resultados de esa busqueda
            string texto = TextBoxBuscar.Text;
            Response.Redirect("ResultadosBusqueda.aspx?texto="+texto);
        }

        //si le das a cerrar sesion
        protected void CerrarOnClick(object sender, EventArgs e)
        {
            //sesion cerrada y refrescar a default (menu cambia al cerrar sesion)
            Session["usuario"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}
