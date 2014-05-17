using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AddEditPelicula : System.Web.UI.Page
    {
        private FilmBiblio.PeliculaEN pelicula= new FilmBiblio.PeliculaEN();

        protected void Page_Load(object sender, EventArgs e)
        {

            String param1 = Request.QueryString["par1"];
            if (param1 == "editarPelicula")
            {
                BotonAddEdit.Text = "Guardar cambios";
            }
            else if (param1 == "anadirPelicula")
            {
                BotonAddEdit.Text = "Añadir película";
            }
            else
            {
                BotonAddEdit.Visible = false;
            }

        }

        protected void BotonAddEditOnClick(object sender, EventArgs e)
        {
            String param1 = Request.QueryString["par1"];
            Response.BufferOutput = true;
            if (param1 == "editarPelicula")
            {
                //Guardar datos y update
                pelicula.Titulo = TextBoxTitulo.Text;
                pelicula.Director = TextBoxDirector.Text;
                pelicula.Ano = int.Parse(TextBoxAno.Text);
                pelicula.Sinopsis = TextBoxSinopsis.Text;
                pelicula.Genero = TextBoxGenero.Text;
                pelicula.Reparto = TextBoxReparto.Text;
                pelicula.BandaSonora = TextBoxBandaSonora.Text;
                pelicula.Trailer = TextBoxTrailer.Text;
                pelicula.UpdatePelicula();
            }
            else if (param1 == "anadirPelicula")
            {
                //Guardar datos y insert
                pelicula.Titulo = TextBoxTitulo.Text;
                pelicula.Director = TextBoxDirector.Text;
                pelicula.Ano = int.Parse(TextBoxAno.Text);
                pelicula.Sinopsis = TextBoxSinopsis.Text;
                pelicula.Genero = TextBoxGenero.Text;
                pelicula.Reparto = TextBoxReparto.Text;
                pelicula.BandaSonora = TextBoxBandaSonora.Text;
                pelicula.Trailer = TextBoxTrailer.Text;
                pelicula.InsertarPelicula();
            }
        }

       
    }
}