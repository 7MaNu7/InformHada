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
    class ComentarioEN
    {
        ///////////
        // Datos //
        ///////////

        private ComentarioCAD comentarioCad = new ComentarioCAD();//Instancia de ComentarioCAD para gestionar la información de usuarios en la base de datos
        private DataSet bd = new DataSet();

        private int id;                      //identificador del comentario
        private string texto;                //contenido del comentario
        private int usuario;                 //identificador para el usuario
        private string fecha;                //fecha en que se realiza el comentario
        private int film;                    //identificador para la serie o pelicula

        ///////////////
        // Funciones //
        ///////////////

        //Constructor por defecto
        public ComentarioEN() { }

        //Constructor con parámetros que son las propiedades de dicho comentario
        public ComentarioEN(int pid, string ptexto, int pusuario, string pfecha, int pfilm)
        {
            id = pid;
            texto = ptexto;
            usuario = pusuario;
            fecha = pfecha;
            film = pfilm;
        }

        //Se inserta en la BD el nuevo caomentario cuyos datos están en esta instancia this de ComentarioEN
        public void InsertarComentario()
        {
            comentarioCad.InsertarComentario(this);
        }

        //Se modifica en la BD un comentario cuyos datos están en esta instancia this de ComentarioEN
        public void UpdateComentario()
        {
            comentarioCad.UpdateComentario(this);
        }

        //Se borra en la BD un comentario diferenciado de los demás por su id
        public void BorrarComentario()
        {
            comentarioCad.BorrarComentario(this.id);
        }

        //Devuelve la información de todos las comentarios
        public DataSet DameComentarios()
        {
            try
            {
                bd = comentarioCad.DameComentarios();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return bd;
        }

        //Devuelve la información del comentario que tiene como clave primaria el id pasado por parámetro
        public ComentarioEN DameComentario()
        {
            ComentarioEN comentario = new ComentarioEN();
            comentario = comentarioCad.DameComentario(this.id);
            return comentario;
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

        //Desde fuera de la clase se puede obtener el texto y modificarlo
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        //Desde fuera de la clase se puede obtener el usuario y modificarlo
        public int Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        //Desde fuera de la clase se puede obtener la fecha y modificarlo
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        //Desde fuera de la clase se puede obtener el film y modificarlo
        public int Film
        {
            get { return film; }
            set { film = value; }
        }
    }
}