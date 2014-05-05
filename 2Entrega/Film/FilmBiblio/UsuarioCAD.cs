using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FilmBiblio
{
    public class UsuarioCAD
    {
        //Cuando un usuario agrega a un amigo, su id y el id de su amigo pasan a la tabla Amigos indicando dicha relación
        public void AnyadirAmigo(int mi_id, int id_amigo) { }

        //Cuando un usuario elimina a un amigo, su id y el id de su amigo se eliminan de la tabla Amigos que indica dicha relación
        public void EliminarAmigo(int mi_id, int id_amigo) { }

        //Realiza una operación select en la BD para añadir un nuevo usuario cuyos datos se pasan por parámetro en el objeto UsuarioEN
        public void InsertarUsuario(UsuarioEN usuario) { }

        //Modifica un usuario en la BD cuyos datos se pasan por parámetro en el objeto UsuarioEN
        public void UpdateUsuario(UsuarioEN usuario) { }

        //Borra un usuario en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarUsuario(int id) { }

        //Devuelve la información de todos los usuarios
        public ArrayList DameUsuarios()
        {
            ArrayList prueba = new ArrayList();     //Para que no de error
            return prueba;
        }

        //Devuelve la información del usuario que tiene como clave primaria el id pasado por parámetro
        public UsuarioEN DameUsuario(int id)
        {
            UsuarioEN prueba = new UsuarioEN();     //Para que no de error
            return prueba;
        }
    }   
}
