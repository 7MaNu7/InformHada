using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FilmBiblio
{
    public class SerieCAD
    {
        //Si un usuario vota una serie, se registra lo que ha votado y se recalcula la puntuación de la serie
        public float AnyadirPuntuacionSerie(int id_usuario, int id, float calificacion) { return 0; /*Para que no de error*/ }

        //Cuando un usuario añade un artista que trabaja en el reparto, se agrega en la BD donde se refleja el reparto de esa serie
        public void AnyadirArtistaSerie(int id, string artista) { }

        //Cuando un usuario elimina un artista del reparto, se elimina en la BD donde se refleja el reparto de esa serie
        public void EliminarArtistaSerie(int id, string artista) { }

        //Realiza una operación select en la BD para añadir una nueva serie cuyos datos se pasan por parámetro en el objeto SerieEN
        public void InsertarSerie(SerieEN serie) { }

        //Modifica una serie en la BD cuyos datos se pasan por parámetro en el objeto SerieEN
        public void UpdateSerie(SerieEN serie) { }

        //Borra una serie en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarSerie(int id) { }

        //Devuelve la información de todas las series
        public ArrayList DameSeries()
        {
            ArrayList prueba = new ArrayList(); //Para que no de error
            return prueba;
        }

        //Devuelve la información de la serie que tiene como clave primaria el id pasado por parámetro
        public SerieEN DameSerie(int id)
        {
            SerieEN prueba = new SerieEN();     //Para que no de error
            return prueba;
        }
    }
}
