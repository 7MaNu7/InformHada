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
    public class UsuarioCAD
    {
        ///////////
        // Datos //
        ///////////

        private string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        
        ///////////////
        // Funciones //
        ///////////////

        public bool SonAmigos(int id1, int id2)
        {
            bool amigos = false;
            string orden = "select id1 from amigos where id1=" + id1 + " and id2=" + id2;
            SqlConnection c = new SqlConnection(conexion);
            
            try
            {
                c.Open();
                SqlCommand select_amigos = new SqlCommand(orden, c);
                SqlDataReader read = select_amigos.ExecuteReader();
                while (read.HasRows)
                {
                    amigos = true;
                    break;
                }
                read.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return amigos;
        }

        //Devuelve el máximo id de la base de datos
        public int MaximoId()
        {
            string orden = "select * from usuario where id=(select max(id) from usuario)";
            int id = 0;
            SqlConnection c = new SqlConnection(conexion);
            SqlDataReader read_id = null;

            try
            {
                c.Open();
                SqlCommand max_id = new SqlCommand(orden, c);
                read_id = max_id.ExecuteReader();
                read_id.Read();
                id=(int)read_id["id"];
                read_id.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { read_id.Close(); c.Close(); }

            return id;
        }

        //Cuando un usuario agrega a un amigo, su id y el id de su amigo pasan a la tabla Amigos indicando dicha relación
        public void AnyadirAmigo(int mi_id, int id_amigo)
        {
            String orden = "insert into amigos values (" + mi_id + ", " + id_amigo+ ")";
            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand insert_usuario = new SqlCommand(orden, c);
                insert_usuario.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Cuando un usuario elimina a un amigo, su id y el id de su amigo se eliminan de la tabla Amigos que indica dicha relación
        public void EliminarAmigo(int mi_id, int id_amigo)
        {
            String orden = "delete from amigos where id1=" + mi_id + " and id2=" + id_amigo;
            SqlConnection c = new SqlConnection(conexion);

            try
            {
                c.Open();
                SqlCommand delete_amigo = new SqlCommand(orden, c);
                delete_amigo.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Realiza una operación select en la BD para añadir un nuevo usuario cuyos datos se pasan por parámetro en el objeto UsuarioEN
        public void InsertarUsuario(UsuarioEN usuario)
        {
            int id = MaximoId();
            id++;

            String orden = "insert into Usuario values ";
            orden += "( " + id + ", ";
            orden += "'" + usuario.Usuario + "', ";
            orden += "'" + usuario.Psswd + "', ";
            orden += "'" + usuario.Pais + "', ";
            orden += "'" + usuario.Provincia + "', ";
            orden += "'" + usuario.FechaNacimiento + "', ";
            orden += "'" + usuario.Sexo + "', ";
            orden += "'" + usuario.Email + "', ";
            orden += "'" + usuario.Informacion + "', ";
            orden += "'" + usuario.FotoPerfil + "', ";
            orden += "'" + usuario.FotoPortada + "')";

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand insert_usuario = new SqlCommand(orden, c);
                insert_usuario.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Modifica un usuario en la BD cuyos datos se pasan por parámetro en el objeto UsuarioEN
        public void UpdateUsuario(UsuarioEN usuario)
        {
            String orden = "update usuario ";
            orden += "set usuario = '" + usuario.Usuario + "', ";
            orden += "psswd = '" + usuario.Psswd + "', ";
            orden += "pais = '" + usuario.Pais + "', ";
            orden += "provincia = '" + usuario.Provincia + "', ";
            orden += "fechaNacimiento = '" + usuario.FechaNacimiento + "', ";
            orden += "sexo = '" + usuario.Sexo + "', ";
            orden += "email = '" + usuario.Email + "', ";
            orden += "informacion = '" + usuario.Informacion + "', ";
            orden += "fotoPerfil = '" + usuario.FotoPerfil + "', ";
            orden += "fotoPortada = '" + usuario.FotoPortada + "' ";
            orden += "where id = " + usuario.Id;

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand update_usuario = new SqlCommand(orden, c);
                update_usuario.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Borra un usuario en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarUsuario(int id)
        {
            //Por claves ajenas y claves primarias es necesario eliminar en este orden
            String orden1 = "delete from Votar where usuario=" + id;
            String orden2 = "delete from Comentario where usuario=" + id;
            String orden3 = "delete from Amigos where id2= " + id;
            String orden4 = "delete from Amigos where id1= " + id;
            String orden5 = "delete from Usuario where id= " + id;

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand delete_usuario = new SqlCommand(orden1, c);
                delete_usuario.ExecuteNonQuery();
                delete_usuario = new SqlCommand(orden2, c);
                delete_usuario.ExecuteNonQuery();
                delete_usuario = new SqlCommand(orden3, c);
                delete_usuario.ExecuteNonQuery();
                delete_usuario = new SqlCommand(orden4, c);
                delete_usuario.ExecuteNonQuery();
                delete_usuario = new SqlCommand(orden5, c);
                delete_usuario.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Devuelve la información de todos los usuarios
        public DataSet DameUsuarios()
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                String select_usuarios = "Select * from film, serie where film.id=serie.id";
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_usuarios, c);
                ejecuta.Fill(bdvirtual, "series");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve la información del usuario que tiene como clave primaria el id pasado por parámetro
        public UsuarioEN DameUsuario(int id)
        {
            SqlConnection c = new SqlConnection(conexion);
            UsuarioEN usuario = new UsuarioEN();

            try
            {
                c.Open();
                SqlCommand select_usuario = new SqlCommand("Select * from usuario where id=" + id, c);
                SqlDataReader read = select_usuario.ExecuteReader();

                read.Read();
                //Finalmente creamos el usuario con sus datos
                usuario.Id = Convert.ToInt32(read["id"].ToString());
                usuario.Usuario = read["usuario"].ToString();
                usuario.Psswd = read["psswd"].ToString();
                usuario.Pais = read["pais"].ToString();
                usuario.Provincia = read["Provincia"].ToString();
                usuario.FechaNacimiento = read["fechaNacimiento"].ToString();
                usuario.Sexo = read["sexo"].ToString();
                usuario.Email = read["email"].ToString();
                usuario.FechaNacimiento = read["fechaNacimiento"].ToString();
                usuario.Informacion = read["informacion"].ToString();
                read.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
            return usuario;
        }

        //Devuelve la información del usuario que tiene como clave primaria el id pasado por parámetro
        public UsuarioEN DameUsuarioPorEmail(string email)
        {
            SqlConnection c = new SqlConnection(conexion);
            UsuarioEN usuario = new UsuarioEN();

            try
            {
                c.Open();
                SqlCommand select_usuario = new SqlCommand("Select * from usuario where email='" + email + "'", c);
                SqlDataReader read = select_usuario.ExecuteReader();
                
                read.Read();
                usuario.Id = Convert.ToInt32(read["id"].ToString());
                usuario.Usuario = read["usuario"].ToString();
                usuario.Psswd = read["psswd"].ToString();
                usuario.Pais = read["pais"].ToString();
                usuario.Provincia = read["Provincia"].ToString();
                usuario.FechaNacimiento = read["fechaNacimiento"].ToString();
                usuario.Sexo = read["sexo"].ToString();
                usuario.Email = read["email"].ToString();
                usuario.FechaNacimiento = read["fechaNacimiento"].ToString();
                usuario.Informacion = read["informacion"].ToString();
                read.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return usuario;
        }

        //Devuelve una bd con los amigos y su información
        public DataSet DameAmigos(int id)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                String select_amigos = "Select id2 from amigos where id1="+id;
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_amigos, c);
                ejecuta.Fill(bdvirtual, "series");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve la información de todas los usuarios que tengan un usuario que contenga el texto
        public DataSet DameUsuariosBusqueda(string texto)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();
            string select_busqueda = "Select * from usuario where usuario like '%" + texto + "%'";

            try
            {
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_busqueda, c);
                ejecuta.Fill(bdvirtual, "usuarios");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve un amigo aleatorio
        public int DameUsuarioAleatorio(int id)
        {
            int id_amigo=0;
            SqlConnection c = new SqlConnection(conexion);
            UsuarioEN usuario = new UsuarioEN();
            string consulta="Select top 1 id2 from amigos where id1="+id+" order by newid()";

            try
            {
                c.Open();
                SqlCommand select_usuario = new SqlCommand(consulta, c);
                SqlDataReader read = select_usuario.ExecuteReader();
                read.Read();
                id_amigo = Convert.ToInt32(read[0].ToString());
                read.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return id_amigo;        
        }

        //Devuelve una bd con los amigos y su información
        public DataSet DameAmigosDeAleatorio(int id_amigo, int id_usuario)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                String select_amigos = "select id2 from amigos where id1=" + id_amigo;
                select_amigos += "and id2!="+id_usuario+" and id2 not in (select id2 from amigos where id1="+id_usuario+")";
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_amigos, c);
                ejecuta.Fill(bdvirtual, "series");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve la información de todas los usuarios que quizás conozca el usuario (amigos de amigos)
        public DataSet DameUsuariosQuizasConozca(int id)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();
            int id_amigo=DameUsuarioAleatorio(id);
            bdvirtual = DameAmigosDeAleatorio(id_amigo, id);            
            return bdvirtual;
        }
    }   
}
