using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WebApplication1
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private FilmBiblio.UsuarioEN usuarioLogeado = new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
           usuarioLogeado = (FilmBiblio.UsuarioEN)Session["usuario"];

            //aparecera iniciar o cerrar sesion dependiendo de si estas logeado o no
            if (usuarioLogeado == null)
            {
                BotonIniciarSesion.Text = "Iniciar Sesión";
            }
            else
                BotonIniciarSesion.Text = "Cerrar sesión";
        }
        //al darle a iniciar o cerrar sesion
        protected void BotonLoginOnClick(object sender, EventArgs e)
        {
            usuarioLogeado = (FilmBiblio.UsuarioEN)Session["usuario"];

            //si le das a iniciar sesion
            if (usuarioLogeado == null)
            {
                Response.Redirect("Login.aspx");
            }
            else   //si le das a cerrar sesion
            {
                Session["usuario"] = null;
                Response.Redirect("Default.aspx");
            }
        }
        //al buscar algo en la barra del encabezado
        protected void BotonBuscarOnClick(object sender, EventArgs e)
        {
            //vamos a la pagina de resultados para esa busqueda
            string texto = TextBoxBuscar.Text;
            Response.Redirect("ResultadosBusqueda.aspx?texto=" + texto);
        }

        /*private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string texto = TextBoxBuscar.Text;
                Response.Redirect("ResultadosBusqueda.aspx?texto=" + texto);
            }
        }*/
    }
}
