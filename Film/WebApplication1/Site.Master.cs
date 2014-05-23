using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private FilmBiblio.UsuarioEN usuarioLogeado = new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuarioLogeado = (FilmBiblio.UsuarioEN)Session["usuario"];
            if (usuarioLogeado == null)
            {
                BotonIniciarSesion.Text = "Iniciar Sesión";
            }
            else
                BotonIniciarSesion.Text = "Cerrar sesión";
        }

        protected void BotonLoginOnClick(object sender, EventArgs e)
        {
            usuarioLogeado = (FilmBiblio.UsuarioEN)Session["usuario"];
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

        protected void BotonBuscarOnClick(object sender, EventArgs e)
        {
            string texto = TextBoxBuscar.Text;
            Response.Redirect("ResultadosBusqueda.aspx?texto=" + texto);
        }
    }
}
