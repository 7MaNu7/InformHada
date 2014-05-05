using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FilmBiblio
{
    public class PeliculaCAD
    {
        //Si un usuario vota una película, se registra lo que ha votado y se recalcula la puntuación de la pelicula
        public float AnyadirPuntuacionPelicula(int id_usuario, int id, float calificacion) { return 0; /*Para que no de error*/ }

        //Cuando un usuario añade un artista que trabaja en el reparto, se agrega en la BD donde se refleja el reparto de esa película
        public void AnyadirArtistaPelicula(int id, string artista) { }

        //Cuando un usuario elimina un artista del reparto, se elimina en la BD donde se refleja el reparto de esa película
        public void EliminarArtistaPelicula(int id, string artista) { }

        //Realiza una operación select en la BD para añadir una nueva película cuyos datos se pasan por parámetro en el objeto PeliculaEN
        public void InsertarPelicula(PeliculaEN pelicula) { }

        //Modifica una película en la BD cuyos datos se pasan por parámetro en el objeto PeliculaEN
        public void UpdatePelicula(PeliculaEN pelicula) { }

        //Borra una película en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarPelicula(int id) { }

        //Devuelve la información de todas las películas
        public ArrayList DamePeliculas() 
        {
            ArrayList prueba=new ArrayList();   //Para que no de error
            return prueba;
        }

        //Devuelve la información de la película que tiene como clave primaria el id pasado por parámetro
        public PeliculaEN DamePelicula(int id)
        {
            PeliculaEN prueba=new PeliculaEN(); //Para que no de error
            return prueba;
        }
    } 
}
