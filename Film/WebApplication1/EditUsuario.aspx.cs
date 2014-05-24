using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class AddEditUsuario : System.Web.UI.Page
    {
        private FilmBiblio.UsuarioEN usuario = new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

            if (!Page.IsPostBack)
            {
                if (usuario != null)
                {
                    LiteralNombre.Text = usuario.Usuario;
                    TextBoxUsuario.Text = usuario.Usuario;
                    TextBoxPais.Text = usuario.Pais;
                    if (usuario.Sexo == "Varón")
                        SexoHombre.Selected = true;
                    else if (usuario.Sexo == "Mujer")
                        SexoMujer.Selected = true;

                    TextBoxProvincia.Text = usuario.Provincia;
                    TextBoxFechaNacimiento.Text = usuario.FechaNacimiento;
                    TextBoxEmail.Text = usuario.Email;
                    TextBoxInformacion.Text = usuario.Informacion;

                    BotonEditar.Text = "Guardar cambios";
                }
            }
            if (Session["usuario"] == null)
            {
                Response.Redirect("Default.aspx");
                //BotonEditar.Text = "Completar registro";
            }
        }

        protected void BotonEditarOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

            if (usuario != null)
            {
                if(Page.IsValid)
                {
                    //Guardar datos y update
                    usuario.Usuario = TextBoxUsuario.Text;
                    if (TextBoxPsswd.Text != "")
                        usuario.Psswd = TextBoxPsswd.Text;
                    usuario.Pais = TextBoxPais.Text;
                    usuario.Provincia = TextBoxProvincia.Text;
                    usuario.FechaNacimiento = TextBoxFechaNacimiento.Text;
                    usuario.Sexo = Sexo.Text;
                    usuario.Email = TextBoxEmail.Text;
                    usuario.Informacion = TextBoxInformacion.Text;

                    usuario.UpdateUsuario();

                    if (FileUpload1.HasFile)
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            FileUpload1.SaveAs(Server.MapPath("~/img/users/portada/") + usuario.Id + ".jpg");
                            //   StatusLabel.Text = "Upload status: File uploaded!";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            //  StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                        }
                    }
                    if (FileUploadControl.HasFile)
                    {
                        try
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/img/users/") + usuario.Id + ".jpg");
                            //   StatusLabel.Text = "Upload status: File uploaded!";
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            //  StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                        }
                    }
                    Response.Redirect("Usuario.aspx");
                }
            }

        }

        //Validaciones

        protected void EmailYaExiste(object sender, ServerValidateEventArgs e)
        {
            string email = TextBoxEmail.Text;
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

            if (usuario.ExisteEmail(email) && usuario.Email != email)
            {
                e.IsValid = false;
            }
        }

    }
}