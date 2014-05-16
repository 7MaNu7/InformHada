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

        //Cuando un usuario agrega a un amigo, su id y el id de su amigo pasan a la tabla Amigos indicando dicha relación
        public void AnyadirAmigo(int mi_id, int id_amigo)
        {
            String orden = "insert into amigos values " + mi_id + ", " + id_amigo;

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand insert_usuario = new SqlCommand(orden, c);
                insert_usuario.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }
        }

        //Cuando un usuario elimina a un amigo, su id y el id de su amigo se eliminan de la tabla Amigos que indica dicha relación
        public void EliminarAmigo(int mi_id, int id_amigo)
        {
            String orden = "delete from amigos where id1=" + mi_id + " and id2=" + id_amigo;

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand delete_amigo = new SqlCommand(orden, c);
                delete_amigo.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }
        }

        //Realiza una operación select en la BD para añadir un nuevo usuario cuyos datos se pasan por parámetro en el objeto UsuarioEN
        public void InsertarUsuario(UsuarioEN usuario)
        {
            String orden = "insert into usuario values ";
            orden += "( " + usuario.Id + ", ";
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

            String orden2 = "";
            
            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand insert_usuario = new SqlCommand(orden, c);
                insert_usuario.ExecuteNonQuery();

                //Vamos agregando cada amigo del usuario a la tabla muchos a muchos llamada amigos (id1, id2)
                SqlCommand insert_amigo = null;
                for (int i = 0; i < usuario.Amigos.Capacity; i++)
                {
                    orden2 = "insert into amigos values " + usuario.Id + ", " + usuario.Amigos[i];
                    insert_amigo = new SqlCommand(orden2, c);
                    insert_amigo.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }
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

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand update_usuario = new SqlCommand(orden, c);
                update_usuario.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }
        }

        //Borra un usuario en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarUsuario(int id)
        {
            String orden = "delete from usuario where id= " + id;
            String orden2 = "delete from amigos where id1= " + id;

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand delete_usuario = new SqlCommand(orden, c);
                delete_usuario.ExecuteNonQuery();
                SqlCommand delete_amigos = new SqlCommand(orden2, c);
                delete_amigos.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }
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
            SqlConnection c = null;
            UsuarioEN usuario = null;

            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand select_usuario = new SqlCommand("Select * from usuario where id=" + id, c);
                SqlDataReader read = select_usuario.ExecuteReader();

                //Para obtener los datos de los amigos del usuario
                SqlCommand select_amigos = new SqlCommand("Select id2 from amigos where id1=" + id, c);
                SqlDataReader read2 = select_amigos.ExecuteReader();
                //Tenemos varios usuarios amigos, array auxiliar donde se introducirán los amigos del usuario uno a uno con sus datos
                ArrayList amigos_aux = new ArrayList();
                while (read2.Read())
                {
                    ArrayList amigos_de_amigos = null;
                    SqlCommand select_amigo = new SqlCommand("Select * from usuario where id=" + (int)read2["id2"], c);
                    SqlDataReader read3 = select_amigo.ExecuteReader();
                    UsuarioEN usuario_aux = new UsuarioEN((int)read3["id"], (string)read3["usuario"], (string)read3["psswd"],
                        (string)read3["pais"], (string)read3["provincia"], (string)read3["FechaNacimiento"], (string)read3["Sexo"],
                        (string)read3["Email"], amigos_de_amigos, (string)read3["informacion"], (string)read3["fotoPerfil"],
                        (string)read3["fotoPortada"]);
                    amigos_aux.Add(read2["id2"]);
                }

                //Finalmente creamos el usuario con sus datos y el array de amigos rellenado
                usuario = new UsuarioEN((int)read["id"], (string)read["usuario"], (string)read["psswd"], (string)read["pais"],
                    (string)read["provincia"], (string)read["fechaNacimiento"], (string)read["sexo"], (string)read["email"],
                    amigos_aux, (string)read["informacion"], (string)read["fotoPerfil"], (string)read["fotoPortada"]); ;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }

            return usuario;
        }

        //Devuelve un array con los amigos y su información
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
    }   
}
