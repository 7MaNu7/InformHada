using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace WebApplication1
{
    public partial class Pelicula : System.Web.UI.Page
    {
        private DataSet d = new DataSet();
        private FilmBiblio.ComentarioEN comentario = new FilmBiblio.ComentarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request.QueryString["id"];

            if (id == null)
            {
                Response.Redirect("peliculas.aspx");
            }
            else
            {
                FilmBiblio.PeliculaEN pelicula = new FilmBiblio.PeliculaEN();
                pelicula.Id = Convert.ToInt32(id);

                BotonEditar.NavigateUrl = "AddEditPelicula.aspx?id="+id;
                BotonReport.NavigateUrl = "Report.aspx";

                pelicula = pelicula.DamePelicula();
                caratula.ImageUrl = pelicula.Caratula;
                fondo.ImageUrl = pelicula.Portada;
                titulo.Text = pelicula.Titulo;
                musica.Text = pelicula.BandaSonora;
                sinopsis.Text = pelicula.Sinopsis;
                trailer.Text = pelicula.Trailer;
                puntuacion.Text = pelicula.Puntuacion.ToString();
                reparto.Text = pelicula.Reparto.ToString();
                ano.Text = pelicula.Ano.ToString();
            }

            if (!Page.IsPostBack)
            {
                comentario.Film = Convert.ToInt32( id);
                d = comentario.DameComentarios();
                ListViewComentarios.DataSource = d;
                ListViewComentarios.DataBind();
            }
        }
    }
}