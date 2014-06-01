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
            Session["usuario"] = null;
        }
        //cuando le das a registrarte
        protected void BotonRegistroOnClick(object sender, EventArgs e)
        {
            //asegurandonos de que no estas logeado
            if (Session["usuario"] == null)
            {
                //los campos tienen que ser validos
                if (Page.IsValid)
                {
                    
                      DateTime fec=Convert.ToDateTime("1/1/1941");
                      if (TextBoxFecha.Text != "")
                          fec = Convert.ToDateTime(TextBoxFecha.Text.ToString());

                    //debe de ser una fecha valida (que sea factible)
                    if (fec.Year < 1900 || fec.Year > 2010)
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

                        if (TextBoxFecha.Text != "")
                            usuario.FechaNacimiento = TextBoxFecha.Text;
                        else
                            usuario.FechaNacimiento = null;

                        usuario.Sexo = Sexo.Text;
                        usuario.Email = TextBoxEmail.Text;
                        //usuario registrado y logeado al mismo tiempo
                        usuario.InsertarUsuario();
                        usuario.Id = usuario.MaximoId();
                        Session["usuario"] = usuario;

                        //bienvenido a la pagina principal
                        Response.Redirect("Default.aspx");                    
                    }
                }
            }
        }

        //Validaciones

        protected void EmailYaExiste(object sender, ServerValidateEventArgs e)
        {
            string email = TextBoxEmail.Text;
            //si se intenta registrar con un email existente el campo no es valido
            if (usuario.ExisteEmail(email))
            {
                ValidarEmailYaExiste.Visible = true;
                e.IsValid = false;
            }
        }

    }
}
