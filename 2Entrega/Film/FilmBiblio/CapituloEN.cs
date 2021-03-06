﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FilmBiblio
{
    public class CapituloEN
    {
        ///////////
        // Patos //
        ///////////

        private CapituloCAD capituloCad;//Instancia de CapituloCAD para gestionar la información de usuarios en la base de datos

        private int id;                 //Se usará como clave primaria en la base de datos
        private string titulo;          //El título del capítulo
        private int temporada;          //La temporada a la que pertenece el capítulo
        private int nCapitulo;          //El número del capítulo en la serie
        private string sinopsis;        //La descripción del capítulo
        private SerieEN serie;          //La serie a la que pertenece el capítulo

        ///////////////
        // Funciones //
        ///////////////

        //Constructor por defecto
        public CapituloEN() { }

        //Constructor con parámetros que son las propiedades de dicho capítulo
        public CapituloEN(int pid, string ptitulo, int ptemporada, int pnCapitulo, string psinopsis, SerieEN pserie)
        {
            id = pid;
            titulo = ptitulo;
            temporada = ptemporada;
            nCapitulo = pnCapitulo;
            sinopsis = psinopsis;
            serie = pserie;
        }

        //Se inserta en la BD el nuevo capítulo cuyos datos están en esta instancia this de CapituloEN
        public void InsertarCapitulo()
        {
            capituloCad.InsertarCapitulo(this);
        }

        //Se modifica en la BD un capítulo cuyos datos están en esta instancia this de CapituloEN
        public void UpdateCapitulo()
        {
            capituloCad.UpdateCapitulo(this);
        }

        //Se borra en la BD un capítulo diferenciado de los demás por su id
        public void BorrarCapitulo()
        {
            capituloCad.BorrarCapitulo(this.id);
        }

        //Devuelve la información de todas los capítulos
        public ArrayList DameCapitulos()
        {
            ArrayList capitulos = new ArrayList();
            capitulos = capituloCad.DameCapitulos();
            return capitulos;
        }

        //Devuelve la información del capítulo que tiene como clave primaria el id pasado por parámetro
        public CapituloEN DameCapitulo()
        {
            CapituloEN capitulo = new CapituloEN();
            capitulo = capituloCad.DameCapitulo(this.id);
            return capitulo;
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

        //Desde fuera de la clase se puede obtener la temporada y modificarla
        public int Temporada
        {
            get { return temporada; }
            set { temporada = value; }
        }

        //Desde fuera de la clase se puede obtener el número del capítulo y modificarlo
        public int N_capitulo
        {
            get { return nCapitulo; }
            set { nCapitulo = value; }
        }

        //Desde fuera de la clase se puede obtener la descripción del capítulo y modificarla
        public String Sinopsis
        {
            get { return sinopsis; }
            set { sinopsis = value; }
        }

        //Desde fuera de la clase se puede obtener la serie a la que pertenece y modificarla
        public SerieEN Serie
        {
            get { return serie; }
            set
            {
                serie.Id = value.Id;
                serie.Titulo = value.Titulo;
                serie.Director = value.Director;
                serie.Ano = value.Ano;
                sinopsis = value.Sinopsis;
                serie.Reparto = value.Reparto;
                serie.BandaSonora = value.BandaSonora;
                serie.Puntuacion=value.Puntuacion;
            }
        }
    }
}
