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
    public class SerieCAD
    {
        ///////////
        // Datos //
        ///////////

        private string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        
        ///////////////
        // Funciones //
        ///////////////

        //True si ha votado este film
        public bool HaVotado(int id_film, int id_usuario)
        {
            bool test = false;
            string orden = "select usuario from votar where usuario=" + id_usuario + " and film=" + id_film;
            SqlConnection c = new SqlConnection(conexion);

            try
            {
                c.Open();
                SqlCommand select_voto = new SqlCommand(orden, c);
                SqlDataReader read = select_voto.ExecuteReader();
                while (read.HasRows)
                {
                    test = true;
                    break;
                }
                read.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return test;
        }

        //Devuelve el máximo id de la base de datos
        public int MaximoId()
        {
            string orden = "select * from film where id=(select max(id) from film)";
            int id = 0;

            SqlConnection c = new SqlConnection(conexion);
            SqlDataReader read_id = null;

            try
            {
                c.Open();

                SqlCommand max_id = new SqlCommand(orden, c);
                read_id = max_id.ExecuteReader();
                while (read_id.Read())
                    id = (int)read_id["id"];
                read_id.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return id;
        }

        //Si un usuario vota una serie, se registra lo que ha votado y se recalcula la puntuación de la serie
        public float AnyadirPuntuacionSerie(int id_usuario, int id, float calificacion)
        {
            float puntos = 0;
            string orden1 = "insert into votar values (" + id_usuario + ", " + id + ", " + calificacion + ")";
            string orden2 = "select avg(voto) from votar where film=" + id;
            string orden3 = "update film set puntuacion=" + puntos + " where id=" + id;
            SqlConnection c = new SqlConnection(conexion);

            try
            {
                c.Open();
                SqlCommand sentencia = new SqlCommand(orden1, c);
                sentencia.ExecuteNonQuery();

                sentencia = new SqlCommand(orden2, c);
                SqlDataReader leer_media = sentencia.ExecuteReader();
                leer_media.Read();
                puntos = Convert.ToInt32(leer_media[0].ToString());
                leer_media.Close();

                sentencia = new SqlCommand(orden3, c);
                sentencia.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return puntos;
        }

        //Realiza una operación select en la BD para añadir una nueva serie cuyos datos se pasan por parámetro en el objeto SerieEN
        public void InsertarSerie(SerieEN serie) 
        {
            int id = MaximoId();
            id++;

            String orden = "insert into film values ";
            orden += "( " + id + ", ";
            orden += "'" + serie.Titulo + "', ";
            orden += "'" + serie.Director + "', ";
            orden += serie.Ano + ", ";
            orden += "'" + serie.Sinopsis + "', ";
            orden += "'" + serie.Genero + "', ";
            orden += "'" + serie.Reparto + "', ";
            orden += "'" + serie.BandaSonora + "', ";
            orden += serie.Puntuacion + ", ";
            orden += "'" + serie.Portada + "', ";
            orden += "'" + serie.Caratula + "', ";
            orden += "'" + serie.Trailer + "')";

            String orden2 = "insert into pelicula values " + "(" + id + ")";

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand insert_serie = new SqlCommand(orden, c);
                insert_serie.ExecuteNonQuery();

                insert_serie = new SqlCommand(orden2, c);
                insert_serie.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Modifica una serie en la BD cuyos datos se pasan por parámetro en el objeto SerieEN
        public void UpdateSerie(SerieEN serie)
        {
            String orden = "update film ";
            orden += "set titulo = '" + serie.Titulo + "', ";
            orden += "director = '" + serie.Director + "', ";
            orden += "ano = " + serie.Ano + ", ";
            orden += "sinopsis = '" + serie.Sinopsis + "', ";
            orden += "genero = '" + serie.Genero + "', ";
            orden += "bandaSonora = '" + serie.BandaSonora + "', ";
            orden += "puntuacion = " + serie.Puntuacion + ", ";
            orden += "portada = " + serie.Portada + ", ";
            orden += "caratula = " + serie.Caratula + " ";
            orden += "trailer = " + serie.Trailer + " ";
            orden += "where id = " + serie.Id;

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand update_pelicula = new SqlCommand(orden, c);
                update_pelicula.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Borra una serie en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarSerie(int id)
        {
            String orden1 = "delete from votar where film=" + id;
            String orden2 = "delete from comentario where film=" + id;
            String orden3 = "delete from serie where id= " + id;
            String orden4 = "delete from film where id= " + id;

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand delete_serie = new SqlCommand(orden1, c);
                delete_serie.ExecuteNonQuery();
                delete_serie = new SqlCommand(orden2, c);
                delete_serie.ExecuteNonQuery();
                delete_serie = new SqlCommand(orden3, c);
                delete_serie.ExecuteNonQuery();
                delete_serie = new SqlCommand(orden4, c);
                delete_serie.ExecuteNonQuery();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Devuelve la información de todas las series
        public DataSet DameSeries()
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                String select_series = "Select * from film, serie where film.id=serie.id";
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_series, c);
                ejecuta.Fill(bdvirtual, "series");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual; 
        }

        //Devuelve la información de la serie que tiene como clave primaria el id pasado por parámetro
        public SerieEN DameSerie(int id)
        {
            SqlConnection c = new SqlConnection(conexion);
            SerieEN serie = new SerieEN();

            try
            {
                c.Open();
                SqlCommand select_pelicula = new SqlCommand("Select * from film where id=" + id, c);
                SqlDataReader read = select_pelicula.ExecuteReader();
                read.Read();
                serie.Id = read.GetInt32(0);
                serie.Titulo = read["titulo"].ToString();
                serie.Director = read["director"].ToString();
                serie.Ano = Convert.ToInt32(read["ano"].ToString());
                serie.Sinopsis = read["sinopsis"].ToString();
                serie.Genero = read["genero"].ToString();
                serie.Reparto = read["reparto"].ToString();
                serie.BandaSonora = read["bandaSonora"].ToString();
                serie.Puntuacion = Convert.ToSingle(read["puntuacion"].ToString());
                serie.Portada = read["portada"].ToString();
                serie.Caratula = read["caratula"].ToString();
                serie.Trailer = read["trailer"].ToString();
                read.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return serie;
        }

        //Devuelve la información de todas las series similares a una en concreto
        public DataSet DameSeriesSimilares(SerieEN serie)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                String select_similares = "Select * from film where genero=" + "'" + serie.Genero + "'";
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_similares, c);
                ejecuta.Fill(bdvirtual, "series");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual; 
        }

        //Devuelve la información de todas las series que tengan un título que contenga el texto
        public DataSet DameSeriesBusqueda(string texto)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();
            string select_busqueda = "Select * from film where titulo is like '%" + texto + "%'";
            select_busqueda+="and id exists in (select id from serie)";

            try
            {
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_busqueda, c);
                ejecuta.Fill(bdvirtual, "series");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }
    }
}
