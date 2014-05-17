using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Usuario : System.Web.UI.Page
    {
        private FilmBiblio.UsuarioEN usuario = new FilmBiblio.UsuarioEN();
        private FilmBiblio.UsuarioEN amigo = new FilmBiblio.UsuarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Request.QueryString["id"]);

            if (id != 0 && Session["usuario"] != null)
            {
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
                amigo.Id = id;
                amigo = amigo.DameUsuario();

                LiteralNombre1.Text = amigo.Usuario;
                LiteralNombre.Text = amigo.Usuario;
                LiteralFechaNacimiento.Text = amigo.FechaNacimiento.ToString();
                LiteralSexo.Text = amigo.Sexo;
                LiteralProvincia.Text = amigo.Provincia;
                LiteralPais.Text = amigo.Pais;
                LiteralEmail1.Text = amigo.Email;
                LiteralEmail.Text = amigo.Email;
                LiteralInformacion.Text = amigo.Informacion;

                if (usuario.sonAmigos(id))
                {
                    BotonAmigo.Text = "Eliminar amigo";
                }
                else
                {
                    BotonAmigo.Text = "Añadir amigo";
                }
            }
            if (Session["usuario"] != null)
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
            }

            HyperLinkAddPelicula.NavigateUrl="AddEditPelicula.aspx?par1=anadirPelicula";
            HyperLinkAddSerie.NavigateUrl="AddEditSerie.aspx?par1=anadirSerie";
            HyperLinkEditUsuario.NavigateUrl="AddEditUsuario.aspx?par1=editarUsuario";
            
            if (Session["usuario"]!=null)
            {
                BotonEditar.Text = "Editar";
            }
            else
            {
                BotonEditar.Visible = false;
            }
        }

        protected void BotonAmigoOnClick(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];

                int id = Convert.ToInt32(Request.QueryString["id"]);

                if (usuario.sonAmigos(id))
                {
                    usuario.EliminarAmigo(amigo);
                }
                else
                {
                    usuario.AnyadirAmigo(amigo);
                }
            }

        }

        protected void EliminarUsuario(object sender, EventArgs e)
        {
            //id??
            HyperLinkEliminarUsuario.NavigateUrl = "Default.aspx";
        }

        protected void BotonEditarOnClick(object sender, EventArgs e)
        {
            String param1 = Request.QueryString["par1"];
            Response.BufferOutput = true;
            if (param1 == "verUsuario")
            {
                Response.Redirect("AddEditUsuario.aspx?par1=editarUsuario");
            }
        
        }
    }
}