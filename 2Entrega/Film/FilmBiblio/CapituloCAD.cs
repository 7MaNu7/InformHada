using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FilmBiblio
{
    public class CapituloCAD
    {
        //Realiza una operación select en la BD para añadir un nuevo capítulo cuyos datos se pasan por parámetro en el objeto CaituloEN
        public void InsertarCapitulo(CapituloEN capitulo) { }

        //Modifica un capítulo en la BD cuyos datos se pasan por parámetro en el objeto CapituloEN
        public void UpdateCapitulo(CapituloEN capitulo) { }

        //Borra un capítulo en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarCapitulo(int id) { }
        
        //Devuelve la información de todos los capítulos
        public ArrayList DameCapitulos()
        {
            ArrayList prueba = new ArrayList();     //Para que no de error
            return prueba;
        }

        //Devuelve la información del capítulo que tiene como clave primaria el id pasado por parámetro
        public CapituloEN DameCapitulo(int id)
        {
            CapituloEN prueba = new CapituloEN();   //Para que no de error
            return prueba;
        }
    }

}
