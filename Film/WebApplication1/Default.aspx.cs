using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        public FilmBiblio.UsuarioEN usuarioLogeado = new FilmBiblio.UsuarioEN();

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
                BotonRegistro.Visible = false;
            }

            HyperLinkPeliculas.NavigateUrl = "Peliculas.aspx?";
            HyperLinkSeries.NavigateUrl = "Series.aspx";
            HyperLinkUsuario.NavigateUrl = "Usuario.aspx?par1=verUsuario";
            HyperLinkAnadirPelicula.NavigateUrl = "AddEditPelicula.aspx?par1=anadirPelicula";
            HyperLinkAnadirSerie.NavigateUrl = "AddEditSerie.aspx?par1=anadirSerie";
            HyperLinkAbout.NavigateUrl = "About.aspx";
            HyperLinkReport.NavigateUrl = "Report.aspx";       
        }

        protected void BotonLoginOnClick(object sender, EventArgs e)
        {
            if (usuarioLogeado == null)
            {
                Response.Redirect("Login.aspx");
            }
            else 
            {
                Session["usuario"] = null;
                Response.Redirect("Default.aspx");
            }
        
        
        }
    }
}
