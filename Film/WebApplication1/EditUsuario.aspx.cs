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
        private FilmBiblio.UsuarioEN usuario=new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

            if (!Page.IsPostBack)
            {
                if (usuario != null)
                {
                    LiteralNombre.Text = usuario.Usuario;
                    TextBoxUsuario.Text = usuario.Usuario;
                    TextBoxPsswd.Text = usuario.Psswd;
                    TextBoxPsswd2.Text = usuario.Psswd;

                    //if(TextBoxPsswd.ToString()=="")

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
            if(Session["usuario"]==null)
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
                //Guardar datos y update
                usuario.Usuario = TextBoxUsuario.Text;
                usuario.Psswd = TextBoxPsswd.Text;
                usuario.Pais = TextBoxPais.Text;
                usuario.Provincia = TextBoxProvincia.Text;
                usuario.FechaNacimiento = TextBoxFechaNacimiento.Text;
                usuario.Sexo = Sexo.Text;
                usuario.Email = TextBoxEmail.Text;
                usuario.Informacion = TextBoxInformacion.Text;

                usuario.UpdateUsuario();
                Response.Redirect("Usuario.aspx");
                if (FileUpload1.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(FileUpload1.FileName);
                        FileUpload1.SaveAs(Server.MapPath("~/img/user/portada/") + usuario.Id + ".jpg");
                        //   StatusLabel.Text = "Upload status: File uploaded!";
                    }
                    catch (Exception ex)
                    {
                        //  StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    }
                }
                if (FileUploadControl.HasFile)
                {
                    try
                    {
                        string filename = Path.GetFileName(FileUploadControl.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/img/user/caratula/") + usuario.Id + ".jpg");
                        //   StatusLabel.Text = "Upload status: File uploaded!";
                    }
                    catch (Exception ex)
                    {
                        //  StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                    }
                }
            }

        }
    }
}