using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace FilmBiblio
{
    public class PeliculaEN
    {
        ///////////
        // Patos //
        ///////////

        private PeliculaCAD peliculaCad = new PeliculaCAD();//Instancia de PeliculaCAD para gestionar la información de usuarios en la base de datos
        private DataSet bd = new DataSet();

        private int id;                 //Se utilizará como clave primaria en la base de datos
        private string titulo;          //El título de la película
        private string director;        //El nombre del director de la película
        private int ano;                //El año en el que se creó la película
        private string sinopsis;        //La descripción de la película
        private string genero;          //El género de la película
        private string reparto;      //El conjunto de artistas/actores de la película
        private string bandaSonora;     //La banda sonora de la película
        private float puntuacion;       //La puntuación media de la película
        private string portada;         //Imagen de la portada de la película
        private string caratula;        //Imagen de la carátula de la película
        private string trailer;         //Trailer de la película

        ///////////////
        // Funciones //
        ///////////////

        //Constructor por defecto
        public PeliculaEN() {}

        //Constructor con parámetros que son las propiedades de dicha película
        public PeliculaEN(int pid, string ptitulo, string pdirector, int pano, string psinopsis, string pgenero, string preparto,
            string pbandaSonora, float puntuacion, string pportada, string pcaratula, string ptrailer)
        {
            id = pid;
            titulo = ptitulo;
            director = pdirector;
            ano = pano;
            sinopsis = psinopsis;
            genero = pgenero;
            reparto = preparto;
            bandaSonora = pbandaSonora;
            this.puntuacion = puntuacion;
            portada = pportada;
            caratula = pcaratula;
            trailer = ptrailer;
        }

        //True si un usuario ha votado este film
        public bool HaVotado(int id_usuario)
        {
            return peliculaCad.HaVotado(this.id, id_usuario);
        }

        //Se añade en la BD la puntuación de un usuario para una película concreta
        public void AnyadirPuntuacionPelicula(int id_usuario, float calificacion)
        {
            //El método AnyadirPuntuacionPelicula de PeliculaCAD devuelve la puntuación recalculada
            puntuacion = peliculaCad.AnyadirPuntuacionPelicula(id_usuario, this.id, calificacion);
        }

        //Se inserta en la BD la nueva película cuyos datos están en esta instancia this de PeliculaEN
        public void InsertarPelicula()
        {
            peliculaCad.InsertarPelicula(this);
        }

        //Se modifica en la BD una película cuyos datos están en esta instancia this de PeliculaEN
        public void UpdatePelicula()
        {
            peliculaCad.UpdatePelicula(this);
        }

        //Se borra en la BD una película diferenciada de las demás por su id
        public void BorrarPelicula()
        {
            peliculaCad.BorrarPelicula(this.id);
        }

        //Devuelve la información de todas las películas
        public DataSet DamePeliculas()
        {
            try
            {
                bd = peliculaCad.DamePeliculas();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return bd;
        }

        //Devuelve la información de la película que tiene como clave primaria el id pasado por parámetro
        public PeliculaEN DamePelicula()
        {
            PeliculaEN pelicula = new PeliculaEN();
            pelicula = peliculaCad.DamePelicula(this.id);
            return pelicula;
        }

        //Devuelve la información de todas las películas similares a una con el id pasado por parámetro
        public DataSet DamePeliculasSimilares()
        {
            bd = peliculaCad.DamePeliculasSimilares(this);
            return bd;
        }

        //Devuelve la información de todas las películas que tengan un título que contenga el texto
        public DataSet DamePeliculasBusqueda(string texto)
        {
            bd = peliculaCad.DamePeliculasBusqueda(texto);
            return bd;
        }

        //Devuelve la información de todas las películas con mejor puntuación (hasta un top)
        public DataSet DamePeliculasMejorPuntuadas(int numero)
        {
            bd = peliculaCad.DamePeliculasMejorPuntuadas(numero);
            return bd;
        }

        //Devuelve la información de todas las películas recientes (hasta un top)
        public DataSet DamePeliculasRecientes(int numero)
        {
            bd = peliculaCad.DamePeliculasRecientes(numero);
            return bd;
        }

        /////////////////
        // Propiedades //
        /////////////////

        //Desde fuera de la clase se puede obtener el id y modificarlo
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        //Desde fuera de la clase se puede obtener el título pero no modificarlo
        public String Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        //Desde fuera de la clase se puede obtener el director y modificarlo
        public String Director
        {
            get { return director; }
            set { director = value; }
        }

        //Desde fuera de la clase se puede obtener el año y modificarlo
        public int Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        //Desde fuera de la clase se puede obtener la descripción de la película y modificarla
        public String Sinopsis
        {
            get { return sinopsis; }
            set { sinopsis = value; }
        }

        //Desde fuera de la clase se puede obtener el género de la película y modificarlo
        public String Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        //Desde fuera de la clase se puede obtener el reparto de actores y modificarlo
        public string Reparto
        {
            get { return reparto; }
            set { reparto = value; }
        }

        //Desde fuera de la clase se puede obtener la banda sonora y modificarla
        public String BandaSonora
        {
            get { return bandaSonora; }
            set { bandaSonora = value; }
        }

        //Desde fuera de la clase se puede obtener la puntuación y modificarla
        public float Puntuacion
        {
            get { return puntuacion; }
            set { puntuacion = value; }
        }

        //Desde fuera de la clase se puede obtener la portada y modificarla
        public String Portada
        {
            get { return portada; }
            set { portada = value; }
        }

        //Desde fuera de la clase se puede obtener la caratula y modificarla
        public String Caratula
        {
            get { return caratula; }
            set { caratula = value; }
        }

        //Desde fuera de la clase se puede obtener el trailer y modificarlo
        public String Trailer
        {
            get { return trailer; }
            set { trailer = value; }
        }
    }
}
