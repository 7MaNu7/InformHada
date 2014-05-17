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

        private string conexion = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
        
        ///////////////
        // Funciones //
        ///////////////

        //Devuelve el máximo id de la base de datos
        public int MaximoId()
        {
            string orden = "select * from film where id=(select max(id) from film)";
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
                read_id.Read();
                id = (int)read_id["id"];
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { read_id.Close(); c.Close(); }
            
            return id;
        }

        //Si un usuario vota una película, se registra lo que ha votado y se recalcula la puntuación de la pelicula
        public float AnyadirPuntuacionPelicula(int id_usuario, int id, float calificacion)
        { 
            return 0; /*Para que no de error*/ 
        }

        //Realiza una operación select en la BD para añadir una nueva película cuyos datos se pasan por parámetro en el objeto PeliculaEN
        public void InsertarPelicula(PeliculaEN pelicula) 
        {
            int id = MaximoId();
            id++;

            String orden ="insert into film values ";
			orden+="( "+ id+", ";
			orden+="'"+pelicula.Titulo+"', ";
			orden+="'"+pelicula.Director+"', ";
            orden += pelicula.Ano +", ";
            orden += "'" + pelicula.Sinopsis + "', ";
            orden += "'" + pelicula.Genero + "', ";
            orden += "'" + pelicula.Reparto + "', ";
            orden += "'" + pelicula.BandaSonora + "', ";
            orden += pelicula.Puntuacion + ", ";
            orden += "'" + pelicula.Portada + "', ";
            orden += "'" + pelicula.Caratula + "', ";
            orden += "'" + pelicula.Trailer + "')";

            String orden2 = "insert into pelicula values "+"( " + id + ", ";

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand insert_pelicula = new SqlCommand(orden, c);
                insert_pelicula.ExecuteNonQuery();
                insert_pelicula = new SqlCommand(orden2, c);
                insert_pelicula.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
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
            orden += "reparto = '" + pelicula.Reparto + "', ";
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
            finally { c.Close(); }
        }

        //Borra una película en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarPelicula(int id)
        {
            String orden = "delete from film where id= " + id;
            String orden2 = "delete from serie where id= " + id;

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
            finally { c.Close(); }
        }

        //Devuelve la información de todas las películas
        public DataSet DamePeliculas() 
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                String select_peliculas = "Select * from film, pelicula where film.id=pelicula.id";
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_peliculas, c);
                ejecuta.Fill(bdvirtual, "peliculas");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;           
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
                read.Read();
                pelicula = new PeliculaEN();
                pelicula.Id = read.GetInt32(0);
                pelicula.Titulo = read["titulo"].ToString();
                pelicula.Director = read["director"].ToString();
                pelicula.Ano = Convert.ToInt32(read["ano"].ToString());
                pelicula.Sinopsis = read["sinopsis"].ToString();
                pelicula.Genero = read["genero"].ToString();
                pelicula.Reparto = read["reparto"].ToString();
                pelicula.BandaSonora = read["bandaSonora"].ToString();
                pelicula.Puntuacion = (float)(read["puntuacion"]);
                pelicula.Portada = read["portada"].ToString();
                pelicula.Caratula = read["caratula"].ToString();
                pelicula.Trailer = read["trailer"].ToString();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return pelicula;
        }


        //Devuelve la información de todas las películas similares a una en concreto
        public DataSet DamePeliculasSimilares(PeliculaEN pelicula)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                String select_similares = "Select * from film where genero="+"'"+pelicula.Genero+"'";
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_similares, c);
                ejecuta.Fill(bdvirtual, "peliculas");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;    
        }
    } 
}
