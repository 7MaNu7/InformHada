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

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
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

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
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
            String orden = "delete from capitulo where id= " + id;

            SqlConnection c = null;
            try
            {
                c = new SqlConnection(conexion);
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
            SqlConnection c = null;
            CapituloEN capitulo = null;
            try
            {
                c = new SqlConnection(conexion);
                c.Open();
                SqlCommand com = new SqlCommand("Select * from capitulo where id=" + id, c);
                SqlDataReader read = com.ExecuteReader();

                //Primero leemos la serie a la que pertenece el capítulo
                SqlCommand buscar_serie = new SqlCommand("Select * from film where id=" + id, c);
                SqlDataReader leer_s = buscar_serie.ExecuteReader();

                //Consulta para leer todos los artistas que forman parte del reparto de la serie a la que pertenece el capítulo
                SqlCommand buscar_reparto = new SqlCommand("Select artista from reparto where id_film=" + id, c);
                SqlDataReader leer_reparto = buscar_serie.ExecuteReader();

                leer_s.Read();
                SerieEN serie_aux = new SerieEN((int)leer_s["id"], (string)leer_s["titulo"], (string)leer_s["director"], (int)leer_s["ano"],
                    (string)leer_s["sinopsis"], (string)leer_s["genero"], (string)leer_s["reparto"], (string)leer_s["bandaSonora"], (float)leer_s["puntuacion"],
                    (string)leer_s["portada"], (string)leer_s["caratula"], (string)leer_s["trailer"]);

                read.Read();
                capitulo = new CapituloEN((int)read["id"], (string)read["titulo"], (int)read["temporada"],
                    (int)read["nCapitulo"], (string)read["sinopsis"], serie_aux);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { c.Close(); }

            return capitulo;
        }
    }

}
