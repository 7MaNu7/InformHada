using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Pelicula : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request.QueryString["id"];

            if (id == null)
            {
                Response.Redirect("peliculas.aspx");
            }
            else
            {
                FilmBiblio.PeliculaEN pelicula = new FilmBiblio.PeliculaEN();
                pelicula.Id = Convert.ToInt32(id);


                pelicula = pelicula.DamePelicula();

                caratula.ImageUrl = pelicula.Caratula;
                fondo.ImageUrl = pelicula.Portada;
                titulo.Text = pelicula.Titulo;
                musica.Text = pelicula.BandaSonora;
                sinopsis.Text = pelicula.Sinopsis;
                trailer.Text = pelicula.Trailer;
                puntuacion.Text = pelicula.Puntuacion.ToString();
                // reparto.Text = pelicula.Reparto.ToString();
                ano.Text = pelicula.Ano.ToString();
            }
        }
    }
}