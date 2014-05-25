using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        private FilmBiblio.UsuarioEN usuario = new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["usuario"] = null;
        }

        protected void IniciarSesionOnClick(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text;
            usuario = usuario.DameUsuarioPorEmail(email);

            if (Page.IsValid)
            {
                Session["usuario"] = usuario;
                Session.Timeout = 30;
                Response.Redirect("Default.aspx");
            }
            else
            {
                
            }

        }

        protected void ComprobarCuenta(object sender, ServerValidateEventArgs e)
        {
            string email = TextBoxEmail.Text;
            string psswd = TextBoxPsswd.Text;
            if (!usuario.ExisteCuenta(email, psswd))
            {
                e.IsValid = false;
            }
        }
    }
}