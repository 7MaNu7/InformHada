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
    public partial class ResultadosBusqueda : System.Web.UI.Page
    {
        public FilmBiblio.UsuarioEN usuarioLogeado = new FilmBiblio.UsuarioEN();
        private DataSet d = new DataSet();
        private FilmBiblio.PeliculaEN pelicula = new FilmBiblio.PeliculaEN();
        private FilmBiblio.SerieEN serie = new FilmBiblio.SerieEN();
        private FilmBiblio.UsuarioEN usuario = new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioLogeado = (FilmBiblio.UsuarioEN)Session["usuario"];

            if (usuarioLogeado == null)
            {
                HyperLinkAnadirPelicula.Visible = false;
                HyperLinkAnadirSerie.Visible = false;
                HyperLinkUsuario.Visible = false;
            }
            else
            {
                HyperRegistro.Visible = false;
            }

            HyperRegistro.NavigateUrl = "Login.aspx";
            HyperLinkPeliculas.NavigateUrl = "Peliculas.aspx";
            HyperLinkSeries.NavigateUrl = "Series.aspx";
            HyperLinkUsuario.NavigateUrl = "Usuario.aspx?par1=verUsuario";
            HyperLinkAnadirPelicula.NavigateUrl = "AddEditPelicula.aspx";
            HyperLinkAnadirSerie.NavigateUrl = "AddEditSerie.aspx";
            HyperLinkAbout.NavigateUrl = "About.aspx";
            HyperLinkReport.NavigateUrl = "Report.aspx";

            String texto = Request.QueryString["texto"];

            if (!Page.IsPostBack)
            {

                if (texto != null && texto != "")
                {
                    int cant = 0;
                   
                    d = pelicula.DamePeliculasBusqueda(texto);
                    ListViewPeliculas.DataSource = d;
                    if (d != null)
                        ListViewPeliculas.DataBind();
                    if (d.Tables[0].Rows.Count == 0)
                        LiteralPeliculas.Text = "No se han encontrado resultados de películas";

                    cant += d.Tables[0].Rows.Count;

                    d = serie.DameSeriesBusqueda(texto);
                    ListViewSeries.DataSource = d;
                    if (d != null)
                        ListViewSeries.DataBind();
                    if (d.Tables[0].Rows.Count == 0)
                        LiteralSeries.Text = "No se han encontrado resultados de películas";

                    cant += d.Tables[0].Rows.Count;

                    /*d = pelicula.DamePeliculasMejorPuntuadas(numero);
                    ListViewCapitulos.DataSource = d;
                    ListViewCapitulos.DataBind();*/

                    d = usuario.DameUsuariosBusqueda(texto);
                    ListViewUsuarios.DataSource = d;
                    ListViewUsuarios.DataBind();

                    if (d != null)
                        ListViewSeries.DataBind();
                    if (d.Tables[0].Rows.Count == 0)
                        LiteralUsuarios.Text = "No se han encontrado resultados de películas";

                    cant += d.Tables[0].Rows.Count;

                    LiteralResultado.Text = cant.ToString() + " resultados de buscar " + "\"" + texto.ToUpper() + "\"";
                }
                else
                    Response.Redirect("Default.aspx");

            }
        }

        protected void BotonBuscarOnClick(object sender, EventArgs e)
        {
            string texto = TextBoxBuscar.Text;
            Response.Redirect("ResultadosBusqueda.aspx?texto=" + texto);
        }
    }
}