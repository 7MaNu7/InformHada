﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FilmBiblio
{
    public class SerieEN
    {
        ///////////
        // Patos //
        ///////////

        private SerieCAD serieCad;      //Instancia de SerieCAD para gestionar la información de usuarios en la base de datos

        private int id;                 //Se utilizará como clave primaria en la base de datos
        private string titulo;          //El título de la serie
        private string director;        //El nombre del director de la serie
        private int ano;                //El año en el que se creó la serie
        private string sinopsis;        //La descripción de la serie
        private ArrayList reparto;      //El conjunto de artistas/actores de la serie
        private string bandaSonora;     //La banda sonora de la serie
        private float puntuacion;       //La puntuación media de la serie

        ///////////////
        // Funciones //
        ///////////////

        //Constructor por defecto
        public SerieEN() {}

        //Constructor con parámetros que son las propiedades de dicha serie
        public SerieEN(int pid, string ptitulo, string pdirector, int pano, string psinopsis, ArrayList preparto, string pbandaSonora, float puntuacion)
        {
            id = pid;
            titulo = ptitulo;
            director = pdirector;
            ano = pano;
            sinopsis = psinopsis;
            reparto = (ArrayList)preparto.Clone();
            bandaSonora = pbandaSonora;
            this.puntuacion = puntuacion;
        }

        //Se añade en la BD la puntuación de un usuario para una serie concreta
        public void AnyadirPuntuacionSerie(int id_usuario, float calificacion)
        {
            //El método AnyadirPuntuacionSerie de SerieCAD devuelve la puntuación recalculada
            puntuacion = serieCad.AnyadirPuntuacionSerie(id_usuario, this.id, calificacion);
        }

        //Se añade en la BD un nuevo artista en el reparto de la serie
        public void AnyadirArtistaSerie(string artista)
        {
            reparto.Add(artista);
            serieCad.AnyadirArtistaSerie(this.id, artista);
        }

        //Se elimina en la BD el artista pasado por parámetro en el reparto de la serie
        public void EliminarArtistaSerie(string artista)
        {
            reparto.Remove(artista);
            serieCad.EliminarArtistaSerie(this.id, artista);
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
        public ArrayList DameSeries()
        {
            ArrayList series = new ArrayList();
            series = serieCad.DameSeries();
            return series;
        }

        //Devuelve la información de la serie que tiene como clave primaria el id pasado por parámetro
        public SerieEN DameSerie()
        {
            SerieEN serie = new SerieEN();
            serie = serieCad.DameSerie(this.id);
            return serie;
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

        //Desde fuera de la clase se puede obtener el reparto de actores y modificarlo
        public ArrayList Reparto
        {
            get { return reparto; }
            set { reparto = (ArrayList)value.Clone(); }
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
    }
}
