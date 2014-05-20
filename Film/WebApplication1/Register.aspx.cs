using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class Register : System.Web.UI.Page
    {
        FilmBiblio.UsuarioEN usuario = new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BotonRegistroOnClick(object sender, EventArgs e)
        {
            if(Session["usuario"]==null)
            {
                //Guardar datos y insert
                usuario.Usuario = TextBoxUsuario.Text;
                usuario.Psswd = TextBoxPsswd.Text;
                usuario.Pais = TextBoxPais.Text;
                usuario.Provincia = TextBoxProvincia.Text;
                usuario.FechaNacimiento =  calendario.Text;
                usuario.Sexo = Sexo.Text;
                usuario.Email = TextBoxEmail.Text;

                usuario.InsertarUsuario();
            }
        }

    }
}
