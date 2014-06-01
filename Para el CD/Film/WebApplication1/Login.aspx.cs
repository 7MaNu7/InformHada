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

        //cuando se le da a iniciar sesion
        protected void IniciarSesionOnClick(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text;
            //a traves del email (que no se repite) obtenemos su usuario
            usuario = usuario.DameUsuarioPorEmail(email);

            //los campos deben ser correctos
            if (Page.IsValid)
            {
                //la sesion es la del usuario cogido antes
                Session["usuario"] = usuario;
                //media hora dura la sesion
                Session.Timeout = 30;
                //despues de iniciar sesion vamos a la pagina principal
                Response.Redirect("Default.aspx");
            }
            else
            {
                
            }

        }
        //validacion de que no exista ya el email
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