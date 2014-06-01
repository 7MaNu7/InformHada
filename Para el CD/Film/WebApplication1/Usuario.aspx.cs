using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace WebApplication1
{
    public partial class Usuario : System.Web.UI.Page
    {
        private FilmBiblio.UsuarioEN usuario = new FilmBiblio.UsuarioEN();
        private FilmBiblio.UsuarioEN amigo = new FilmBiblio.UsuarioEN();
        private DataSet d = new DataSet();


        protected void Page_Load(object sender, EventArgs e)
        {
            //sacamos el id de usuario de la url
            int id = Convert.ToInt32(Request.QueryString["id"]);

            //si esta logeado pero viendo un usuario (id) distinto al suyo
            if (id != 0 && Session["usuario"] != null)
            {
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

                string id_usuario = Request.QueryString["id"];
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
                amigo.Id = id;
                amigo = amigo.DameUsuario();

                Page.Title = amigo.Usuario;

                
                if (Convert.ToInt32(id_usuario) != usuario.Id)
                {
                    //no puedes editar un usuario ajeno al tuyo
                    BotonEditar.Visible = false;
                    //ni ver sus recomendaciones de "quizas conzozcas a"
                    Panel1.Visible = false;
                }
                //mostrar los datos del usuario y sus imagenes
                if (amigo.FechaNacimiento != null && amigo.FechaNacimiento!="")
                {
                    DateTime fechanacimiento = Convert.ToDateTime(amigo.FechaNacimiento);
                    LiteralFechaNacimiento.Text = fechanacimiento.ToShortDateString();
                }
                LiteralNombre1.Text = amigo.Usuario;
                LiteralNombre.Text = amigo.Usuario;
                LiteralSexo.Text = amigo.Sexo;
                LiteralProvincia.Text = amigo.Provincia;
                LiteralPais.Text = amigo.Pais;
                LiteralEmail1.Text = amigo.Email;
                LiteralEmail.Text = amigo.Email;
                LiteralInformacion.Text = amigo.Informacion;

                imgperfil.ImageUrl = "~/img/users/" + amigo.Id.ToString() + ".jpg";
                portada.ImageUrl = "~/img/users/portada/" + amigo.Id.ToString() + ".jpg";

                //si lo tienes agregado lo puedes eliminar
                if (usuario.sonAmigos(id))
                {
                    BotonAmigo.Text = "Eliminar amigo";
                }
                else  //si no lo tienes de amigo puedes agregarlo
                {
                    BotonAmigo.Text = "Añadir amigo";
                }
            }   //si estas logeado y viendo tu propio usuario
            else if (Session["usuario"] != null && id == 0)
            {
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

                Page.Title = usuario.Usuario;

                //mostrar datos de la bd
                if(usuario.FechaNacimiento!=null && usuario.FechaNacimiento!="")
                    usuario.FechaNacimiento.ToString();
                
                LiteralNombre1.Text = usuario.Usuario;
                LiteralNombre.Text = usuario.Usuario;
               
                if(usuario.FechaNacimiento != null && usuario.FechaNacimiento!="")
                {
                    LiteralFechaNacimiento.Text = Convert.ToDateTime(usuario.FechaNacimiento.ToString()).ToShortDateString();
                }
                
                LiteralSexo.Text = usuario.Sexo;
                LiteralProvincia.Text = usuario.Provincia;
                LiteralPais.Text = usuario.Pais;
                LiteralEmail1.Text = usuario.Email;
                LiteralEmail.Text = usuario.Email;
                LiteralInformacion.Text = usuario.Informacion;

                //imagenes guardadas
                imgperfil.ImageUrl = "~/img/users/" + usuario.Id.ToString() + ".jpg";
                portada.ImageUrl = "~/img/users/portada/" + usuario.Id.ToString() + ".jpg";

            }
            else  //si tratas de ver usuario sin logearte
            {
                Response.Redirect("Error.aspx");
            }
            //herramientas del usuario
            HyperLinkAddPelicula.NavigateUrl = "AddEditPelicula.aspx?par1=anadirPelicula";
            HyperLinkAddSerie.NavigateUrl = "AddEditSerie.aspx?par1=anadirSerie";

            //para editar tienes que estar logeado
            if (Session["usuario"] != null)
            {
                BotonEditar.Text = "Editar";
            }
            else
            {
                BotonEditar.Visible = false;
            }
            //cantidad de amigos y "quizas conozcas a" a mostrar
            int cantidad = 5;

            if (id == usuario.Id || id == 0)
            {
                BotonAmigo.Visible = false;

                //lista de amigos
                d = usuario.DameAmigos(cantidad);
                ListViewAmigos.DataSource = d;
                ListViewAmigos.DataBind();

                if (d.Tables[0].Rows.Count != 0)
                {
                    //lista de sugerencias
                    d = usuario.DameUsuariosQuizasConozca(cantidad);
                    ListViewQuizasConozcas.DataSource = d;
                    ListViewQuizasConozcas.DataBind();
                }
            }

            //si no es tu usuario no puedes editar ni eliminar cuenta
            if (!Page.IsPostBack && id != 0)
            {
                d = amigo.DameAmigos(cantidad);
                ListViewAmigos.DataSource = d;
                ListViewAmigos.DataBind();

                d = amigo.DameUsuariosQuizasConozca(cantidad);
                ListViewQuizasConozcas.DataSource = d;
                ListViewQuizasConozcas.DataBind();

                BotonEditar.Visible = false;
                BotonEliminarUsuario.Visible = false;
            }


        }
        //boton de añadir/eliminar amigo
        protected void BotonAmigoOnClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            //no tiene que ser tu propio usuario, pero tienes que estar logeado
            if (Session["usuario"] != null && id != 0)
            {
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

                amigo.Id = id;
                amigo = amigo.DameUsuario();

                //si lo tienes agregado has optado por eliminar
                if (usuario.sonAmigos(id))
                {
                    usuario.EliminarAmigo(amigo);
                    Response.Redirect("Usuario.aspx?id=" + id);
                }
                else   //sino por añadir
                {
                    usuario.AnyadirAmigo(amigo);
                    Response.Redirect("Usuario.aspx?id=" + id);
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
            
            usuario.BorrarUsuario();
            Session["usuario"] = usuario = null;
            Response.Redirect("Default.aspx");

        }
        //editar cuenta
        protected void BotonEditarOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            if (usuario != null)
            {
                Response.Redirect("EditUsuario.aspx");
            }
        }
        //ver más 
        protected void VerMasAmigosOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            int id = Convert.ToInt32(Request.QueryString["id"]);
            
            if (usuario != null && id != 0) //ver amigos de otros
            {
                Response.Redirect("VerMasAmigos.aspx?id=" + id.ToString());
            }
            else if (id == 0 && usuario != null) //ver tus propios amigos
            {
                Response.Redirect("VerMasAmigos.aspx?id=" + usuario.Id.ToString());
            }
            else if (usuario == null) //para ver amigos de otros te tienes que loguear
            {
                Response.Redirect("Login.aspx");
            }
        }
        //ver mas usuarios sugeridos
        protected void VerMasPosiblesAmigosOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            //"quizas conozcas a" solo se muestra al propio usuario, no en los demas perfiles
            
            if (usuario != null)
            { //se sacaran amigos de amigo
             
                   Response.Redirect("VerMasUsuarios.aspx");
             
            }
        }
    }
}