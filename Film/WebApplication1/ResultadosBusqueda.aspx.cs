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

            //no se pueden hacer cosas de la parte privada sin estar logeado
            if (usuarioLogeado == null)
            {
                HyperLinkAnadirPelicula.Visible = false;
                HyperLinkAnadirSerie.Visible = false;
                HyperLinkUsuario.Visible = false;
            }
            else
            {   
                //si estas logeado no sale la opcion de logearse
                HyperRegistro.Visible = false;
            }
            //direcciones a las que se accede al pulsar en el menu
            HyperRegistro.NavigateUrl = "Login.aspx";
            HyperLinkPeliculas.NavigateUrl = "Peliculas.aspx";
            HyperLinkSeries.NavigateUrl = "Series.aspx";
            HyperLinkUsuario.NavigateUrl = "Usuario.aspx?par1=verUsuario";
            HyperLinkAnadirPelicula.NavigateUrl = "AddEditPelicula.aspx";
            HyperLinkAnadirSerie.NavigateUrl = "AddEditSerie.aspx";
            HyperLinkAbout.NavigateUrl = "About.aspx";
            HyperLinkReport.NavigateUrl = "Report.aspx";

            //lo que se ha buscado lo cogemos de la url
            String texto = Request.QueryString["texto"];

            if (!Page.IsPostBack)
            {
                //si se ha buscado algo
                if (texto != null && texto != "")
                {
                    //contara la cantidad de resultados
                    int cant = 0;
                   
                    //mostramos las peliculas de la busqueda
                    d = pelicula.DamePeliculasBusqueda(texto);
                    ListViewPeliculas.DataSource = d;
                    if (d != null)
                        ListViewPeliculas.DataBind();
                    if (d.Tables[0].Rows.Count == 0)
                        LiteralPeliculas.Text = "No se han encontrado resultados de películas";

                    cant += d.Tables[0].Rows.Count;

                    //mostramos las series de la busqueda
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

                    //mostramos los usuarios de la busqueda
                    d = usuario.DameUsuariosBusqueda(texto);
                    ListViewUsuarios.DataSource = d;
                    ListViewUsuarios.DataBind();

                    if (d != null)
                        ListViewSeries.DataBind();
                    if (d.Tables[0].Rows.Count == 0)
                        LiteralUsuarios.Text = "No se han encontrado resultados de películas";

                    cant += d.Tables[0].Rows.Count;

                    //mensaje de resultados encontrados
                    LiteralResultado.Text = cant.ToString() + " resultados de buscar " + "\"" + texto.ToUpper() + "\"";
                }
                else     //si no se ha hecho busqueda valida
                    Response.Redirect("Default.aspx");

            }
        }

        //en la pagina de resultados se puede buscar
        protected void BotonBuscarOnClick(object sender, EventArgs e)
        {
            //se vuelve a esta pagina con la nueva busqueda
            string texto = TextBoxBuscar.Text;
            Response.Redirect("ResultadosBusqueda.aspx?texto=" + texto);
        }
    }
}