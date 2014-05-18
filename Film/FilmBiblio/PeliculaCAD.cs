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

        //True si ha votado este film
        public bool HaVotado(int id_film, int id_usuario)
        {
            bool test = false;
            string orden = "select usuario from votar where usuario=" + id_usuario+" and film="+id_film;
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
                read_id.Read();
                id = (int)read_id["id"];
                read_id.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
            
            return id;
        }

        //Si un usuario vota una película, se registra lo que ha votado y se recalcula la puntuación de la pelicula
        public float AnyadirPuntuacionPelicula(int id_usuario, int id, float calificacion)
        {
            float puntos=0;
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

            String orden2 = "insert into pelicula values "+"( " + id + ") ";

            SqlConnection c = new SqlConnection(conexion);
            try
            {
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
            String orden = "update Film ";
            orden += "set titulo = '" + pelicula.Titulo + "', "; 
            orden += "director = '" + pelicula.Director + "', ";
            orden += "ano = " + pelicula.Ano + ", ";
            orden += "sinopsis = '" + pelicula.Sinopsis + "', ";
            orden += "genero = '" + pelicula.Genero + "', "; 
            orden += "reparto = '" + pelicula.Reparto + "', ";
            orden += "bandaSonora = '" + pelicula.BandaSonora + "', ";
            orden += "puntuacion = " + pelicula.Puntuacion + ", ";
            orden += "portada = '" + pelicula.Portada + "', ";
            orden += "caratula = '" + pelicula.Caratula + "', ";
            orden += "trailer = '" + pelicula.Trailer + "' ";
            orden += "where id = " + pelicula.Id;

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

        //Borra una película en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarPelicula(int id)
        {
            String orden1 = "delete from votar where film="+id;
            String orden2 = "delete from comentario where film="+id;
            String orden3 = "delete from pelicula where id= "+id;
            String orden4 = "delete from film where id= "+id;

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand delete_pelicula = new SqlCommand(orden1, c);
                delete_pelicula.ExecuteNonQuery();
                delete_pelicula = new SqlCommand(orden2, c);
                delete_pelicula.ExecuteNonQuery();
                delete_pelicula = new SqlCommand(orden3, c);
                delete_pelicula.ExecuteNonQuery();
                delete_pelicula = new SqlCommand(orden4, c);
                delete_pelicula.ExecuteNonQuery();
                
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
            SqlConnection c = new SqlConnection(conexion);
            PeliculaEN pelicula = new PeliculaEN();

            try
            {
                c.Open();
                SqlCommand select_pelicula = new SqlCommand("Select * from film where id=" +id , c);
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
                pelicula.Puntuacion = Convert.ToSingle(read["puntuacion"].ToString());
                pelicula.Portada = read["portada"].ToString();
                pelicula.Caratula = read["caratula"].ToString();
                pelicula.Trailer = read["trailer"].ToString();
                read.Close();
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

        //Devuelve la información de todas las películas que tengan un título que contenga el texto
        public DataSet DamePeliculasBusqueda(string texto)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();
            string select_busqueda = "Select * from film where titulo is like '%" + texto + "%'";
            select_busqueda += "and id exists in (select id from pelicula)";

            try
            {
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_busqueda, c);
                ejecuta.Fill(bdvirtual, "peliculas");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve la información de todas las películas con mejor puntuación (hasta un top)
        public DataSet DamePeliculasMejorPuntuadas(int numero)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();
            string select = "Select * top " + numero + " from pelicula order by puntuacion desc";

            try
            {
                SqlDataAdapter ejecuta = new SqlDataAdapter(select, c);
                ejecuta.Fill(bdvirtual, "peliculas");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve la información de todas las peliculas recientes (hasta un top)
        public DataSet DamePeliculasRecientes(int numero)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();
            string select = "Select * top " + numero + " from pelicula order by id desc";

            try
            {
                SqlDataAdapter ejecuta = new SqlDataAdapter(select, c);
                ejecuta.Fill(bdvirtual, "peliculas");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }
    } 
}
