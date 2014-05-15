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
    public class PeliculaCAD
    {
        ///////////
        // Datos //
        ///////////

        //private string conexion = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ToString();
        private string conexion = @"data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\aspnetdb.mdf;User Instance=true";

        ///////////////
        // Funciones //
        ///////////////

        //Si un usuario vota una película, se registra lo que ha votado y se recalcula la puntuación de la pelicula
        public float AnyadirPuntuacionPelicula(int id_usuario, int id, float calificacion)
        { 
            return 0; /*Para que no de error*/ 
        }

        //Cuando un usuario añade un artista que trabaja en el reparto, se agrega en la BD donde se refleja el reparto de esa película
        public void AnyadirArtistaPelicula(int id, string artista)
        {
            String orden = "insert into reparto values " + id + ", " + artista;

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand insert_artista = new SqlCommand(orden, c);
                insert_artista.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }
        }

        //Cuando un usuario elimina un artista del reparto, se elimina en la BD donde se refleja el reparto de esa película
        public void EliminarArtistaPelicula(int id, string artista)
        {
            String orden = "delete from reparto where id_film=" + id + " and artista='" + artista +"'";

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand delete_artista = new SqlCommand(orden, c);
                delete_artista.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }
        }

        //Realiza una operación select en la BD para añadir una nueva película cuyos datos se pasan por parámetro en el objeto PeliculaEN
        public void InsertarPelicula(PeliculaEN pelicula) 
        {
            String orden ="insert into film values ";
			orden+="( "+pelicula.Id+", ";
			orden+="'"+pelicula.Titulo+"', ";
			orden+="'"+pelicula.Director+"', ";
            orden += pelicula.Ano +", ";
            orden += "'" + pelicula.Sinopsis + "', ";
            orden += "'" + pelicula.Genero + "', ";
            orden += "'" + pelicula.BandaSonora + "', ";
            orden += pelicula.Puntuacion + ", ";
            orden += "'" + pelicula.Portada + "', ";
            orden += "'" + pelicula.Caratula + "', ";
            orden += "'" + pelicula.Trailer + "')";

            String orden2 = "";

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand insert_pelicula = new SqlCommand(orden, c);
                insert_pelicula.ExecuteNonQuery();

                //Para insertar cada artista de la película en la tabla reparto (id_film, artista)
                for (int i = 0; i < pelicula.Reparto.Capacity; i++)
                {
                    orden2 = "insert into reparto values " + pelicula.Id + ", " + pelicula.Reparto[i];
                    SqlCommand insert_reparto = new SqlCommand(orden2, c);
                    insert_reparto.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }
        }

        //Modifica una película en la BD cuyos datos se pasan por parámetro en el objeto PeliculaEN
        public void UpdatePelicula(PeliculaEN pelicula)
        {
            String orden = "update film ";
            orden += "set titulo = '" + pelicula.Titulo + "', ";
            orden += "director = '" + pelicula.Director + "', ";
            orden += "ano = " + pelicula.Ano + ", ";
            orden += "sinopsis = '" + pelicula.Sinopsis + "', ";
            orden += "genero = '" + pelicula.Genero + "', ";
            orden += "bandaSonora = '" + pelicula.BandaSonora + "', ";
            orden += "puntuacion = " + pelicula.Puntuacion + ", ";
            orden += "portada = " + pelicula.Portada + ", ";
            orden += "caratula = " + pelicula.Caratula + ", ";
            orden += "caratula = " + pelicula.Trailer + " ";
            orden += "where id = " + pelicula.Id;

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand update_pelicula = new SqlCommand(orden, c);
                update_pelicula.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }
        }

        //Borra una película en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarPelicula(int id)
        {
            String orden = "delete from film where id= " + id;
            String orden2 = "delete from reparto where id_film= " + id;

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand delete_pelicula = new SqlCommand(orden, c);
                delete_pelicula.ExecuteNonQuery();
                SqlCommand delete_reparto = new SqlCommand(orden2, c);
                delete_reparto.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }
        }

        //Devuelve la información de todas las películas
        public ArrayList DamePeliculas() 
        {
            ArrayList peliculas = new ArrayList();
            SqlConnection c = null;

            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand select_peliculas = new SqlCommand("Select id from film, pelicula where film.id=pelicula.id", c);
                SqlDataReader read = select_peliculas.ExecuteReader();

                //Tenemos varios id de películas, vamos agregando una por una las películas con DamePelicula pasándole cada id
                while (read.Read())
                    peliculas.Add(DamePelicula((int)read["id"]));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }

            return peliculas;
        }

        //Devuelve la información de la película que tiene como clave primaria el id pasado por parámetro
        public PeliculaEN DamePelicula(int id)
        {
            SqlConnection c = null;
            PeliculaEN pelicula = null;

            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand select_pelicula = new SqlCommand("Select * from film where id=" + id, c);
                SqlDataReader read = select_pelicula.ExecuteReader();

                //Consulta para leer todos los artistas que forman parte del reparto de la película
                SqlCommand select_artista = new SqlCommand("Select artista from reparto where id_film=" + id, c);
                SqlDataReader leer_artistas = select_artista.ExecuteReader();

                ArrayList reparto_aux = new ArrayList();
                //Varias filas de artistas, agregamos los artistas a un array
                while (leer_artistas.Read())
                    reparto_aux.Add(leer_artistas["artista"]);

                pelicula = new PeliculaEN((int)read["id"], (string)read["titulo"], (string)read["director"], (int)read["ano"],
                    (string)read["sinopsis"], (string)read["genero"], reparto_aux, (string)read["bandaSonora"], (float)read["puntuacion"],
                    (string)read["portada"], (string)read["caratula"], (string)read["trailer"]);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }

            return pelicula;
        }

        //Devuelve la información de todas las películas similares a una en concreto
        public ArrayList DamePeliculasSimilares(int id)
        {
            ArrayList peliculas = new ArrayList();
            SqlConnection c = null;

            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand select_genero = new SqlCommand("Select genero from film where id="+id, c);
                SqlDataReader read_genero = select_genero.ExecuteReader();
                string genero=(string)read_genero["genero"];
                SqlCommand select_peliculas = new SqlCommand("Select id from film where genero="+genero, c);
                SqlDataReader read = select_peliculas.ExecuteReader();

                //Tenemos varios id de películas, vamos agregando una por una las películas con DamePelicula pasándole cada id
                while (read.Read())
                    peliculas.Add(DamePelicula((int)read["id"]));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally
            {
                c.Close();
            }

            return peliculas;
        }
    } 
}
