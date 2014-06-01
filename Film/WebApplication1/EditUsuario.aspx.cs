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
                //para editar tu usuario tendras que estar logeado primero
                if (usuario != null)
                {
                    //se cogen todos los campos y las imagenes guardadas por defecto
                    LiteralNombre.Text = usuario.Usuario;
                    TextBoxUsuario.Text = usuario.Usuario;
                    caratula.ImageUrl = "/img/users/" + usuario.Id + ".jpg";
                    fondo.ImageUrl = "/img/users/portada/" + usuario.Id + ".jpg";
                    TextBoxPais.Text = usuario.Pais;
                    if (usuario.Sexo == "Varón")
                        SexoHombre.Selected = true;
                    else if (usuario.Sexo == "Mujer")
                        SexoMujer.Selected = true;

                    TextBoxProvincia.Text = usuario.Provincia;

                    if (usuario.FechaNacimiento != null && usuario.FechaNacimiento!="")
                    {
                        DateTime fechanacimiento = Convert.ToDateTime(usuario.FechaNacimiento);
                        TextBoxFechaNacimiento.Text = fechanacimiento.ToShortDateString();
                    }
                    
                    TextBoxEmail.Text = usuario.Email;
                    TextBoxInformacion.Text = usuario.Informacion;

                    BotonEditar.Text = "Guardar cambios";
                }
            }
            //en cambio si intentas editar sin logearte se impide
            if (Session["usuario"] == null)
            {
                Response.Redirect("Error.aspx");
            }
        }

        //al pulsar editar en mi usuario
        protected void BotonEditarOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

            if (usuario != null)
            {
                //tienen que cumplirse las validaciones de los campos
                if(Page.IsValid)
                {
                    DateTime fec = Convert.ToDateTime("01/01/1941");
                    if (TextBoxFechaNacimiento.Text != "")
                        fec = Convert.ToDateTime(TextBoxFechaNacimiento.Text.ToString());
                    //se debe escoger una fecha razonable, que sea verdadera
                    if (fec.Year < 1940 || fec.Year > 2010)
                    {
                        ValidandoFecha.IsValid = false;
                        ValidandoFecha.Visible = true;
                    }
                    else
                    {

                        //Guardar datos y update
                        usuario.Usuario = TextBoxUsuario.Text;
                        if (TextBoxPsswd.Text != "")
                            usuario.Psswd = TextBoxPsswd.Text;
                        usuario.Pais = TextBoxPais.Text;
                        usuario.Provincia = TextBoxProvincia.Text;

                        if (TextBoxFechaNacimiento.Text != "")
                            usuario.FechaNacimiento = TextBoxFechaNacimiento.Text;
                        else
                            usuario.FechaNacimiento = null;

                        usuario.Sexo = Sexo.Text;
                        usuario.Email = TextBoxEmail.Text;
                        usuario.Informacion = TextBoxInformacion.Text;

                        usuario.UpdateUsuario();
                        //si se ha editado el fondo 
                        if (FileUpload2.HasFile)
                        {
                            try
                            {
                                //guardamos el archivo en el directorio especificado
                                string filename = Path.GetFileName(FileUpload1.FileName);
                                FileUpload2.SaveAs(Server.MapPath("~/img/users/portada/") + usuario.Id + ".jpg");
                                //   StatusLabel.Text = "Upload status: File uploaded!";
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                //  StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                            }
                        }
                        //si se ha editado la foto de perfil
                        if (FileUploadControl.HasFile)
                        {
                            try
                            {
                                //guardamos el archivo en el directorio especificado
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
                        //tras editar se vuelve a mi usuario
                        Response.Redirect("Usuario.aspx");
                    }
                }
            }

        }
        //eliminar cuenta
        protected void BotonEliminarUsuarioOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            // Delete a file by using File class static method...
            string path;
            string path2;
            path = Server.MapPath("~/img/users/") + usuario.Id + ".jpg";
            path2 = Server.MapPath("~/img/users/portada/") + usuario.Id + ".jpg";
            if (System.IO.File.Exists(path2))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(path2);
                }
                catch (System.IO.IOException g)
                {
                    Console.WriteLine(g.Message);
                    return;
                }
            }
            if (System.IO.File.Exists(path))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(path);
                }
                catch (System.IO.IOException g)
                {
                    Console.WriteLine(g.Message);
                    return;
                }
            }
            //borramos el usuario, cerramos sesion, y vuelta a la pagina principal
            usuario.BorrarUsuario();
            Session["usuario"] = usuario = null;
            Response.Redirect("Default.aspx");
        }

        //Validaciones

        protected void EmailYaExiste(object sender, ServerValidateEventArgs e)
        {
            string email = TextBoxEmail.Text;
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            //si ya esta en la base de datos no es una entrada valida para el campo
            if (usuario.ExisteEmail(email) && usuario.Email != email)
            {
                e.IsValid = false;
            }
        }

    }
}