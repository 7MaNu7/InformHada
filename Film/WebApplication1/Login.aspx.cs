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

        }

        protected void IniciarSesionOnClick(object sender, EventArgs e)
        {
            string email = TextBoxEmail.ToString();
            usuario = usuario.DameUsuarioPorEmail(email);

            if (usuario == null)
                Response.Write(@"<script language='javascript'>alert('No hay un usuario con este email');</script>");
            else
            {
               if (usuario.Psswd != TextBoxPsswd.ToString())
                usuario = null;
               else
               {
                   Session["usuario"] = usuario;
                   Response.Redirect("Default.aspx");
               }
            }
            
        }
    }
}