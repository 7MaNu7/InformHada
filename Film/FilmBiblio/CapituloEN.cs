﻿using System;
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
    public class CapituloEN
    {
        ///////////
        // Datos //
        ///////////

        private CapituloCAD capituloCad = new CapituloCAD();//Instancia de CapituloCAD para gestionar la información de usuarios en la base de datos
        private DataSet bd = new DataSet();

        private int id;                 //Se usará como clave primaria en la base de datos
        private string titulo;          //El título del capítulo
        private int temporada;          //La temporada a la que pertenece el capítulo
        private int nCapitulo;          //El número del capítulo en la serie
        private string sinopsis;        //La descripción del capítulo
        private int serie;          //La serie a la que pertenece el capítulo

        ///////////////
        // Funciones //
        ///////////////

        //Constructor por defecto
        public CapituloEN() { }

        //Constructor con parámetros que son las propiedades de dicho capítulo
        public CapituloEN(int pid, string ptitulo, int ptemporada, int pnCapitulo, string psinopsis, int pserie)
        {
            id = pid;
            titulo = ptitulo;
            temporada = ptemporada;
            nCapitulo = pnCapitulo;
            sinopsis = psinopsis;
            serie = pserie;
        }

        //True si la temporada ya contiene ese número del capítulo para una serie
        public bool TemporadaCapituloRepetido(int id_serie, int temporada, int ncapitulo)
        {
            return capituloCad.TemporadaCapituloRepetido(id_serie, temporada, ncapitulo);
        }

        //Devuelve cuantas temporadas hay
        public int Temporadas(int id_serie)
        {
            return capituloCad.Temporadas(id_serie);
        }

        //Devuelve el máximo id de la base de datos
        public int MaximoId()
        {
            return capituloCad.MaximoId();
        }

        //Se inserta en la BD el nuevo capítulo cuyos datos están en esta instancia this de CapituloEN
        public int InsertarCapitulo()
        {
            return capituloCad.InsertarCapitulo(this);
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
        public DataSet DameCapitulos(int id)
        {
            bd = capituloCad.DameCapitulos(id);
            return bd;
        }

        //Devuelve la información del capítulo que tiene como clave primaria el id pasado por parámetro
        public CapituloEN DameCapitulo()
        {
            CapituloEN capitulo = new CapituloEN();
            capitulo = capituloCad.DameCapitulo(this.id);
            return capitulo;
        }

        //Devuelve la información de todas los capitulos que tengan un título que contenga el texto
        public DataSet DameCapitulosBusqueda(string texto)
        {
            bd = capituloCad.DameCapitulosBusqueda(texto);
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
        public int Serie
        {
            get { return serie; }
            set { serie = value; }
        }
    }
}
