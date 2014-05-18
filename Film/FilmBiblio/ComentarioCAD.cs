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

        //Inserta un comentario en la BD
        public void InsertarComentario(ComentarioEN comentario)
        {
            String orden = "insert into comentario values ";
            orden += "( " + comentario.Id + ", ";
            orden += "'" + comentario.Fecha + "', ";
            orden += "'" + comentario.Texto + "', ";
            orden += comentario.Usuario + ", ";
            orden += comentario.Film + ")";

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand insert_comentario = new SqlCommand(orden, c);
                insert_comentario.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //No se cambian ni la película a la que refiere ni el autor (usuario)
        public void UpdateComentario(ComentarioEN comentario)
        {
            String orden = "update comentario ";
            orden += "set fecha = '" + comentario.Fecha + "', ";
            orden += "texto = '" + comentario.Texto + "', ";
            orden += "where id = " + comentario.Id;

            SqlConnection c = new SqlConnection(conexion);
            try
            {
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

            SqlConnection c = new SqlConnection(conexion);
            try
            {
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
            SqlConnection c = new SqlConnection(conexion);
            ComentarioEN comentario = new ComentarioEN();

            try
            {
                c.Open();
                SqlCommand select_comentario = new SqlCommand("select * from comentario where id=" + id, c);
                SqlDataReader read = select_comentario.ExecuteReader();
                read.Read();
                comentario.Id = Convert.ToInt32(read["id"].ToString());
                comentario.Fecha = read["fecha"].ToString();
                comentario.Texto = read["texto"].ToString();
                comentario.Usuario = Convert.ToInt32(read["usuario"].ToString());
                comentario.Film = Convert.ToInt32(read["film"].ToString());
                read.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return comentario;
        }

        //Devuelve la información de todas los comentarios que contenga el texto
        public DataSet DameComentariosBusqueda(string texto)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();
            string select_busqueda = "Select * from comentarios where texto is like '%" + texto + "%'";

            try
            {
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_busqueda, c);
                ejecuta.Fill(bdvirtual, "comentarios");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }
    }
}