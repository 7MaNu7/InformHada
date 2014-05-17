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

        //Devuelve el máximo id de la base de datos
        public int MaximoId()
        {
            string orden = "select * from usuario where id=(select max(id) from usuario)";
            int id = 0;

            SqlConnection c = null;
            SqlDataReader read_id = null;

            try
            {
                c = new SqlConnection(conexion);
                c.Open();

                SqlCommand max_id = new SqlCommand(orden, c);
                read_id = max_id.ExecuteReader();
                //max_id.ExecuteNonQuery();
                while (read_id.Read())
                    id = (int)read_id["id"];
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { read_id.Close(); c.Close(); }

            return id;
        }

        //Si un usuario vota una serie, se registra lo que ha votado y se recalcula la puntuación de la serie
        public float AnyadirPuntuacionSerie(int id_usuario, int id, float calificacion)
        { 
            return 0; /*Para que no de error*/ 
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

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand insert_pelicula = new SqlCommand(orden, c);
                insert_pelicula.ExecuteNonQuery();
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

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
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
            String orden = "delete from film where id= " + id;
            String orden2 = "delete from reparto where id_film= " + id;

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand delete_serie = new SqlCommand(orden, c);
                delete_serie.ExecuteNonQuery();
                SqlCommand delete_reparto = new SqlCommand(orden2, c);
                delete_reparto.ExecuteNonQuery();
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
            SqlConnection c = null;
            SerieEN serie = null;

            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand select_serie = new SqlCommand("Select * from film where id=" + id, c);
                SqlDataReader read = select_serie.ExecuteReader();

                //Consulta para leer todos los artistas que forman parte del reparto de la serie
                SqlCommand select_artista = new SqlCommand("Select artista from reparto where id_film=" + id, c);
                SqlDataReader leer_artistas = select_artista.ExecuteReader();

                ArrayList reparto_aux = new ArrayList();
                //Varias filas de artistas, agregamos los artistas a un array
                while (leer_artistas.Read())
                    reparto_aux.Add(leer_artistas["artista"]);

                read.Read();
                serie = new SerieEN((int)read["id"], (string)read["titulo"], (string)read["director"], (int)read["ano"],
                    (string)read["sinopsis"], (string)read["genero"], (string)read["reparto"], (string)read["bandaSonora"],
                    (float)read["puntuacion"], (string)read["portada"], (string)read["caratula"], (string)read["trailer"]);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return serie;
        }

        //Devuelve la información de todas las películas similares a una en concreto
        public DataSet DameSeriesSimilares(SerieEN serie)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                String select_similares = "Select * from film where genero=" + "'" + serie.Genero + "'";
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_similares, c);
                ejecuta.Fill(bdvirtual, "peliculas");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual; 
        }
    }
}
