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
    public class CapituloCAD
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
            string orden = "select * from capitulo where id=(select max(id) from capitulo)";
            int id = 0;

            SqlConnection c = new SqlConnection(conexion);

            try
            {
                c.Open();
                SqlCommand max_id = new SqlCommand(orden, c);
                SqlDataReader read_id = max_id.ExecuteReader();
                while (read_id.Read())
                    id = (int)read_id["id"];
                read_id.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return id;
        }

        //Realiza una operación select en la BD para añadir un nuevo capítulo cuyos datos se pasan por parámetro en el objeto CaituloEN
        public void InsertarCapitulo(CapituloEN capitulo) 
        {
            int id = MaximoId();
            id++;

            String orden = "insert into capitulo values ";
            orden += "( " + id + ", ";
            orden += "'" + capitulo.Titulo + "', ";
            orden += capitulo.Temporada + ", ";
            orden += capitulo.N_capitulo + ", ";
            orden += "'" + capitulo.Sinopsis + "')";
            orden += capitulo.Serie.Id + ")";

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand insert_capitulo = new SqlCommand(orden, c);
                insert_capitulo.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Modifica un capítulo en la BD cuyos datos se pasan por parámetro en el objeto CapituloEN
        public void UpdateCapitulo(CapituloEN capitulo)
        {
            String orden = "update capitulo ";
            orden += "set titulo = '" + capitulo.Titulo + "', ";
            orden += "temporada = '" + capitulo.Temporada + "', ";
            orden += "nCapitulo = " + capitulo.N_capitulo + ", ";
            orden += "sinopsis = '" + capitulo.Sinopsis + "', ";
            orden += "serie = '" + capitulo.Serie.Id + "' ";
            orden += "where id = " + capitulo.Id;

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand update_capitulo = new SqlCommand(orden, c);
                update_capitulo.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }

        //Borra un capítulo en la BD que tiene la clave primaria que se pasa por parámetro
        public void BorrarCapitulo(int id)
        {

            string orden = "delete from capitulo where id= " + id;

            SqlConnection c = new SqlConnection(conexion);
            try
            {
                c.Open();
                SqlCommand delete_capitulo = new SqlCommand(orden, c);
                delete_capitulo.ExecuteNonQuery();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }
        }
        
        //Devuelve la información de todos los capítulos
        public DataSet DameCapitulos()
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();

            try
            {
                String select_capitulos = "Select * from film, serie where film.id=serie.id";
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_capitulos, c);
                ejecuta.Fill(bdvirtual, "series");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }

        //Devuelve la información del capítulo que tiene como clave primaria el id pasado por parámetro
        public CapituloEN DameCapitulo(int id)
        {
            SqlConnection c = new SqlConnection(conexion);
            CapituloEN capitulo = new CapituloEN();
            SerieEN serie = new SerieEN();

            try
            {
                c.Open();
                
                //Primero leemos la serie a la que pertenece el capítulo
                SqlCommand buscar_serie = new SqlCommand("Select * from film where id=" + id, c);
                SqlDataReader leer_s = buscar_serie.ExecuteReader();

                leer_s.Read();
                serie.Id = Convert.ToInt32(leer_s["id"].ToString());
                serie.Titulo = leer_s["titulo"].ToString();
                serie.Director = leer_s["diretor"].ToString();
                serie.Ano =  Convert.ToInt32(leer_s["ano"].ToString());
                serie.Sinopsis = leer_s["sinopsis"].ToString();
                serie.Genero = leer_s["genero"].ToString();
                serie.Reparto = leer_s["reparto"].ToString();
                serie.BandaSonora = leer_s["bandaSonora"].ToString();
                serie.Puntuacion =  Convert.ToInt32(leer_s["puntuacion"].ToString());
                serie.Portada = leer_s["portada"].ToString();
                serie.Caratula = leer_s["caratula"].ToString();
                serie.Trailer = leer_s["trailer"].ToString();
                leer_s.Close();

                //Leemos el capítulo y asignamos la serie a la que pertenece
                SqlCommand com = new SqlCommand("Select * from capitulo where id=" + id, c);
                SqlDataReader read = com.ExecuteReader();
                read.Read();
                capitulo.Id = Convert.ToInt32(read["id"].ToString());
                capitulo.Titulo = read["titulo"].ToString();
                capitulo.Temporada = Convert.ToInt32(read["temporada"].ToString());
                capitulo.N_capitulo = Convert.ToInt32(read["nCapitulo"].ToString());
                capitulo.Sinopsis = read["sinopsis"].ToString();
                capitulo.Serie = serie;
                read.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return capitulo;
        }

        //Devuelve la información de todas los capítulos que tengan un título que contenga el texto
        public DataSet DameCapitulosBusqueda(string texto)
        {
            SqlConnection c = new SqlConnection(conexion);
            DataSet bdvirtual = new DataSet();
            string select_busqueda = "Select * from capitulo where titulo is like '%" + texto + "%'";

            try
            {
                SqlDataAdapter ejecuta = new SqlDataAdapter(select_busqueda, c);
                ejecuta.Fill(bdvirtual, "capitulos");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return bdvirtual;
        }
    }

}
