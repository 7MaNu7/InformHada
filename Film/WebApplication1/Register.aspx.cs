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
                if (Page.IsValid)
                {
                    //Guardar datos y insert
                    usuario.Usuario = TextBoxUsuario.Text;
                    usuario.Psswd = TextBoxPsswd.Text;
                    usuario.Pais = TextBoxPais.Text;
                    usuario.Provincia = TextBoxProvincia.Text;
                    usuario.FechaNacimiento = calendario.Text;
                    usuario.Sexo = Sexo.Text;
                    usuario.Email = TextBoxEmail.Text;

                    usuario.InsertarUsuario();
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    /*ValidarUsuarioRelleno.Visible = false;
                    ValidarEmailRelleno.Visible = false;
                    ValidarEmailYaExiste.Visible = false;
                    ValidarPsswdIguales.Visible = false;
                    ValidarPsswdRelleno.Visible = false;
                    ValidarPsswdRelleno2.Visible = false;*/
                    ValidarEmailYaExiste.Visible = false;
                    ValidarPsswdIguales.Visible = false;
                    CuadroValidacion.ShowMessageBox = true;
                    CuadroValidacion.ShowSummary = true;
                }
            }
        }

        //Validaciones

        protected void EmailYaExiste(object sender, ServerValidateEventArgs e)
        {
            string email = TextBoxEmail.Text;
            if (usuario.ExisteEmail(email))
            {
                e.IsValid = false;
            }
        }

        protected void ComprobarPsswd(object sender, ServerValidateEventArgs e)
        {
            string psswd1 = TextBoxPsswd.Text;
            string psswd2 = TextBoxPsswd2.Text;
            if (psswd1 != psswd2)
            {
                e.IsValid = false;
                ValidarPsswdRelleno2.IsValid = false;
                ValidarPsswdRelleno.IsValid = false;
            }
        }

    }
}
