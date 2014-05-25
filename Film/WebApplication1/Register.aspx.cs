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
            if (Session["usuario"] == null)
            {
                if (Page.IsValid)
                {
                      DateTime fec=Convert.ToDateTime("1/1/1941");
                      if (TextBoxFecha.Text != "")
                      
                          fec = Convert.ToDateTime(TextBoxFecha.Text.ToString());

                    if (fec.Year < 1940 || fec.Year > 2010)
                    {
                        ValidandoFecha.IsValid = false;
                        ValidandoFecha.Visible = true;
                    }
                    else
                    {
                        //Guardar datos y insert
                        usuario.Usuario = TextBoxUsuario.Text;
                        usuario.Psswd = TextBoxPsswd.Text;
                        usuario.Pais = TextBoxPais.Text;
                        usuario.Provincia = TextBoxProvincia.Text;
                        usuario.FechaNacimiento = TextBoxFecha.Text;
                        usuario.Sexo = Sexo.Text;
                        usuario.Email = TextBoxEmail.Text;

                        usuario.InsertarUsuario();
                        Response.Redirect("Default.aspx");                    
                    }
                }
            }
        }

        //Validaciones

        protected void EmailYaExiste(object sender, ServerValidateEventArgs e)
        {
            string email = TextBoxEmail.Text;
            if (usuario.ExisteEmail(email))
            {
                ValidarEmailYaExiste.Visible = true;
                e.IsValid = false;
            }
        }

    }
}
