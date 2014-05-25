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
            int id = Convert.ToInt32(Request.QueryString["id"]);

            if (id != 0 && Session["usuario"] != null)
            {

                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

                string id_usuario = Request.QueryString["id"];
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
                amigo.Id = id;
                amigo = amigo.DameUsuario();

                if (Convert.ToInt32(id_usuario) != usuario.Id)
                {
                    BotonEditar.Visible = false;
                    Panel1.Visible = false;
                }
                DateTime fechanacimiento = Convert.ToDateTime( amigo.FechaNacimiento);
                LiteralNombre1.Text = amigo.Usuario;
                LiteralNombre.Text = amigo.Usuario;
                LiteralFechaNacimiento.Text = fechanacimiento.ToShortDateString();
                LiteralSexo.Text = amigo.Sexo;
                LiteralProvincia.Text = amigo.Provincia;
                LiteralPais.Text = amigo.Pais;
                LiteralEmail1.Text = amigo.Email;
                LiteralEmail.Text = amigo.Email;
                LiteralInformacion.Text = amigo.Informacion;

                imgperfil.ImageUrl = "~/img/users/" + amigo.Id.ToString() + ".jpg";
                portada.ImageUrl = "~/img/users/portada/" + amigo.Id.ToString() + ".jpg";

                if (usuario.sonAmigos(id))
                {
                    BotonAmigo.Text = "Eliminar amigo";
                }
                else
                {
                    BotonAmigo.Text = "Añadir amigo";
                }
            }
            else if (Session["usuario"] != null && id == 0)
            {
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
                LiteralNombre1.Text = usuario.Usuario;
                LiteralNombre.Text = usuario.Usuario;
                LiteralFechaNacimiento.Text = usuario.FechaNacimiento.ToString();
                LiteralSexo.Text = usuario.Sexo;
                LiteralProvincia.Text = usuario.Provincia;
                LiteralPais.Text = usuario.Pais;
                LiteralEmail1.Text = usuario.Email;
                LiteralEmail.Text = usuario.Email;
                LiteralInformacion.Text = usuario.Informacion;

                imgperfil.ImageUrl = "~/img/users/" + usuario.Id.ToString() + ".jpg";
                portada.ImageUrl = "~/img/users/portada/" + usuario.Id.ToString() + ".jpg";

            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            HyperLinkAddPelicula.NavigateUrl="AddEditPelicula.aspx?par1=anadirPelicula";
            HyperLinkAddSerie.NavigateUrl="AddEditSerie.aspx?par1=anadirSerie";
            
            if (Session["usuario"]!=null)
            {
                BotonEditar.Text = "Editar";
            }
            else
            {
                BotonEditar.Visible = false;
            }

            if (id == usuario.Id || id == 0)
            {
                BotonAmigo.Visible = false;
                
                d = usuario.DameAmigos();
                ListViewAmigos.DataSource = d;
                ListViewAmigos.DataBind();

                d = usuario.DameUsuariosQuizasConozca();
                ListViewQuizasConozcas.DataSource = d;
                ListViewQuizasConozcas.DataBind();
            }


            if (!Page.IsPostBack && id!=0 )
            {
                d = amigo.DameAmigos();
                ListViewAmigos.DataSource = d;
                ListViewAmigos.DataBind();

                d = amigo.DameUsuariosQuizasConozca();
                ListViewQuizasConozcas.DataSource = d;
                ListViewQuizasConozcas.DataBind();

                BotonEditar.Visible = false;
                BotonEliminarUsuario.Visible = false;
            }


        }

        protected void BotonAmigoOnClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
                
            if (Session["usuario"] != null && id!=0)
            {
               usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

                amigo.Id = id;
                amigo = amigo.DameUsuario();

                if (usuario.sonAmigos(id))
                {
                    usuario.EliminarAmigo(amigo);
                    Response.Redirect("Usuario.aspx?id=" + id);
                }
                else
                {
                    usuario.AnyadirAmigo(amigo);
                    Response.Redirect("Usuario.aspx?id=" + id);
                }
            }

        }

        protected void BotonEliminarUsuarioOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            usuario.BorrarUsuario();
            Session["usuario"] = usuario = null;
            Response.Redirect("Default.aspx");
        }

        protected void BotonEditarOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            if (usuario!=null)
            {
                Response.Redirect("EditUsuario.aspx");
            }
        }

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