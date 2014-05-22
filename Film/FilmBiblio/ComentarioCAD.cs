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

        //Devuelve el máximo id de la base de datos
        public int MaximoId()
        {
            string orden = "select * from comentario where id=(select max(id) from comentario)";
            int id = 0;
            SqlConnection c = new SqlConnection(conexion);
            SqlDataReader read_id = null;

            try
            {
                c.Open();
                SqlCommand max_id = new SqlCommand(orden, c);
                read_id = max_id.ExecuteReader();
                read_id.Read();
                id = (int)read_id["id"];
                read_id.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { read_id.Close(); c.Close(); }

            id++;
            return id;
        }

        public void InsertarComentario(ComentarioEN comentario)
        {
            int id = MaximoId();

            String orden = "insert into comentario values ";
            orden += "( " + id + ", ";
            orden += "'" + comentario.Fecha + "', ";
            orden += "'" + comentario.Texto + "', ";
            orden += comentario.Usuario + ", ";
            if (comentario.Capitulo == 0)
                orden += comentario.Film + ", NULL )";
            else
                orden += comentario.Film + ", " + comentario.Capitulo + ")";

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
            string consulta="select comentario.* from comentario, film where id="+id;

            try
            {
                c.Open();
                SqlCommand select_comentario = new SqlCommand(consulta, c);
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
            string select_busqueda = "Select * from comentarios where texto like '%" + texto + "%'";

            try
            {
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_busqueda, c);
                ejecuta.Fill(bdvirtual, "comentarios");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve los comentarios de una película/serie
        public DataSet DameComentariosFilm(int id_film)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                string select_comentarios = "select * from Comentario where Comentario.film =" + id_film;

                SqlDataAdapter ejecuta = new SqlDataAdapter(select_comentarios, c);
                ejecuta.Fill(bdvirtual, "comentarios");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve los comentarios de un capítulo
        public DataSet DameComentariosCapitulo(int id_capitulo)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                string select_comentarios = "select * from Comentario where Comentario.capitulo=" + id_capitulo;
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_comentarios, c);
                ejecuta.Fill(bdvirtual, "comentarios");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve los comentarios más recientes de un usuario
        public DataSet DameComentariosRecientesUsuario(int id_usuario)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                string select_comentarios = "select top 5 * from comentario where usuario=" + id_usuario + " order by fecha desc";
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_comentarios, c);
                ejecuta.Fill(bdvirtual, "comentarios");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }
    }
}