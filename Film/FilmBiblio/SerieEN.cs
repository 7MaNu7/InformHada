using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace FilmBiblio
{
    public class SerieEN
    {
        ///////////
        // Datos //
        ///////////

        private SerieCAD serieCad = new SerieCAD();      //Instancia de SerieCAD para gestionar la información de usuarios en la base de datos
        private DataSet bd = new DataSet();

        private int id;                 //Se utilizará como clave primaria en la base de datos
        private string titulo;          //El título de la serie
        private string director;        //El nombre del director de la serie
        private int ano;                //El año en el que se creó la serie
        private string sinopsis;        //La descripción de la serie
        private string genero;          //El género de la serie
        private string reparto;      //El conjunto de artistas/actores de la serie
        private string bandaSonora;     //La banda sonora de la serie
        private float puntuacion;       //La puntuación media de la serie
        private string portada;         //Imagen de la portada de la serie
        private string caratula;        //Imagen de la carátula de la serie
        private string trailer;         //Trailer de la serie

        ///////////////
        // Funciones //
        ///////////////

        //Constructor por defecto
        public SerieEN() {}

        //Constructor con parámetros que son las propiedades de dicha serie
        public SerieEN(int pid, string ptitulo, string pdirector, int pano, string psinopsis, string genero, string preparto,
            string pbandaSonora, float ppuntuacion, string pportada, string pcaratula, string ptrailer)
        {
            id = pid;
            titulo = ptitulo;
            director = pdirector;
            ano = pano;
            sinopsis = psinopsis;
            reparto = preparto;
            bandaSonora = pbandaSonora;
            puntuacion = ppuntuacion;
            portada = pportada;
            caratula = pcaratula;
            Trailer = ptrailer;
        }

        //Se añade en la BD la puntuación de un usuario para una serie concreta
        public void AnyadirPuntuacionSerie(int id_usuario, float calificacion)
        {
            //El método AnyadirPuntuacionSerie de SerieCAD devuelve la puntuación recalculada
            puntuacion = serieCad.AnyadirPuntuacionSerie(id_usuario, this.id, calificacion);
        }

        //Se inserta en la BD la nueva serie cuyos datos están en esta instancia this de SerieEN
        public void InsertarSerie()
        {
            serieCad.InsertarSerie(this);
        }

        //Se modifica en la BD una serie cuyos datos están en esta instancia this de SerieEN
        public void UpdateSerie()
        {
            serieCad.UpdateSerie(this);
        }

        //Se borra en la BD una serie diferenciada de las demás por su id
        public void BorrarSerie()
        {
            serieCad.BorrarSerie(this.id);
        }

        //Devuelve la información de todas las series
        public DataSet DameSeries()
        {
            bd = serieCad.DameSeries();
            return bd;
        }

        //Devuelve la información de la serie que tiene como clave primaria el id pasado por parámetro
        public SerieEN DameSerie()
        {
            SerieEN serie = new SerieEN();
            serie = serieCad.DameSerie(this.id);
            return serie;
        }

        //Devuelve la información de todas las series similares a una con el id pasado por parámetro
        public DataSet DameSeriesSimilares()
        {
            bd = serieCad.DameSeriesSimilares(this);
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

        //Desde fuera de la clase se puede obtener la descripción de la serie y modificarla
        public String Sinopsis
        {
            get { return sinopsis; }
            set { sinopsis = value; }
        }

        //Desde fuera de la clase se puede obtener el genero de la serie y modificarlo
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

        //Desde fuera de la clase se puede obtener la puntuacion y modificarla
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
