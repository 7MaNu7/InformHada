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

        }

        protected void BotonAddEditOnClick(object sender, EventArgs e)
        {
            String param1 = Request.QueryString["par1"];
            Response.BufferOutput = true;
            if (param1 == "editarPelicula")
            {
                //Guardar datos y update
                /*        private int id;                 //Se utilizará como clave primaria en la base de datos
        private string titulo;          //El título de la película
        private string director;        //El nombre del director de la película
        private int ano;                //El año en el que se creó la película
        private string sinopsis;        //La descripción de la película
        private string genero;          //El género de la película
        private ArrayList reparto;      //El conjunto de artistas/actores de la película
        private string bandaSonora;     //La banda sonora de la película
        private float puntuacion;       //La puntuación media de la película
        private string portada;         //Imagen de la portada de la película
        private string caratula;        //Imagen de la carátula de la película
        private string trailer;         //Trailer de la película*/

                

            }
            else if (param1 == "anadirPelicula")
            {
                /*/Guardar datos y insert
                usuario.Usuario = TextBoxUsuario.Text;
                usuario.Psswd = TextBoxPsswd.Text;
                usuario.Pais = TextBoxPais.Text;
                usuario.Provincia = TextBoxProvincia.Text;
                usuario.FechaNacimiento = TextBoxFechaNacimiento.Text;
                usuario.Sexo = Sexo.Text;
                usuario.Email = TextBoxEmail.Text;
                usuario.Informacion = TextBoxInformacion.Text;

                usuario.InsertarUsuario();*/
            }
        }

       /* protected void Button_anadir(object sender, EventArgs e)
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