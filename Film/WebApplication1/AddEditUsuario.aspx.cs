using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using FilmBiblio.UsuarioEN;

namespace WebApplication1
{
    public partial class AddEditUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String param1 = Request.QueryString["par1"];
            if (param1 == "editarUsuario")
            {
                BotonEditar.Text = "Guardar cambios";
            }
            else if (param1 == "registrarUsuario")
            {
                BotonEditar.Text = "Completar registro";
            }
            else
            {
                BotonEditar.Visible = false;
            }
        }

        protected void BotonEditarOnClick(object sender, EventArgs e)
        {
            String param1 = Request.QueryString["par1"];
            Response.BufferOutput = true;
            if (param1 == "editarUsuario")
            {
                //Guardar datos y update
            }
            else if (param1 == "registrarUsuario")
            {
                //Guardar datos y insert
            }
        }

         /*protected void Button_anadir(object sender, EventArgs e)
         {
             PeliculaEN pelicula = new PeliculaEN();
             pelicula.Titulo = TextBoxTitulo.Text;
             pelicula.Director = TextBoxDirector.Text;
             pelicula.Ano = TextBoxAno.Text;
             pelicula.Sinopsis = TextBoxAnoSinopsis.text;
             pelicula.Genero = TextBoxGenero.text;
             //pelicula.Reparto = TextBoxAno.Reparto;
             pelicula.BandaSonora = TextBoxBandaSonora.text;
             pelicula.Portada = TextBoxPortada.text;
             pelicula.Caratula = TextBoxCaratula.text;
             pelicula.Trailer = TextBoxTrailer.text;
             pelicula.InsertarCliente();
         }*/

    }
}