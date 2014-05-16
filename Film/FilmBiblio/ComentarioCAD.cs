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
    class ComentarioCAD
    {
        ///////////
        // Datos //
        ///////////

        private string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();

        ///////////////
        // Funciones //
        ///////////////

        public void InsertarComentario(ComentarioEN comentario)
        {
            String orden = "insert into comentario values ";
            orden += "( " + comentario.Id + ", ";
            orden += "'" + comentario.Fecha + "', ";
            orden += "'" + comentario.Texto + "', ";
            orden += comentario.Usuario + ", ";
            orden += comentario.Film + ")";

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand insert_comentario = new SqlCommand(orden, c);
                insert_comentario.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        public void UpdateComentario(ComentarioEN comentario)
        {
            String orden = "update comentario ";
            orden += "set fecha = '" + comentario.Fecha + "', ";
            orden += "texto = '" + comentario.Texto + "', ";
            orden += "where id = " + comentario.Id;

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand update_comentario = new SqlCommand(orden, c);
                update_comentario.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Borra un comentario en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarComentario(int id)
        {
            String orden = "delete from comentario where id= " + id;

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand delete_comentario = new SqlCommand(orden, c);
                delete_comentario.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Devuelve la información de todos los comentarios
        public DataSet DameComentarios()
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                String select_comentarios = "Select * from comentario";
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_comentarios, c);
                ejecuta.Fill(bdvirtual, "comentarios");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve la información del comentario que tiene como clave primaria el id pasado por parámetro
        public ComentarioEN DameComentario(int id)
        {
            SqlConnection c = null;
            ComentarioEN comentario = null;

            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand select_comentario = new SqlCommand("Select * from comentario where id=" + id, c);
                SqlDataReader read = select_comentario.ExecuteReader();

                comentario = new ComentarioEN((int)read["id"], (string)read["texto"], (int)read["usuario"],
                    (string)read["fecha"], (int)read["film"]);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return comentario;
        }
    }
}
