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
using AjaxControlToolkit;

namespace WebApplication1
{
    public partial class Pelicula : System.Web.UI.Page
    {
        private  FilmBiblio.PeliculaEN pelicula = new FilmBiblio.PeliculaEN();
        private DataSet d = new DataSet();
        private FilmBiblio.ComentarioEN comentario = new FilmBiblio.ComentarioEN();
        private FilmBiblio.UsuarioEN usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                BotonEditar.Visible = false;
            }
            else
            {
                
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            }
            
            String id = Request.QueryString["id"];
            if (id == null)
            {
                Response.Redirect("peliculas.aspx");
            }
            else
            {
               
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
            if (usuario != null)
                Rating1.CurrentRating = Convert.ToInt32(Math.Round( Convert.ToDecimal( pelicula.Puntuacion)/2));
            else
                Rating1.Visible = false;
            if (!Page.IsPostBack)
            {
                comentario.Film = Convert.ToInt32( id);
                d = comentario.DameComentarios();
                ListViewComentarios.DataSource = d;
                ListViewComentarios.DataBind();
            }
        }
        protected void OnRatingChanged(object sender, RatingEventArgs e)
        {
         //   pelicula.Puntuacion = Convert.ToSingle( e.Value.ToString());
            //titulo.Text = "Holaaaaaaaaaaaaaa";
            if (usuario != null)
            {
                pelicula.AnyadirPuntuacionPelicula(usuario.Id, Convert.ToSingle(e.Value.ToString()) * 2);
                pelicula.DamePelicula();
                puntuacion.Text = pelicula.Puntuacion.ToString();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
              //  

            //   e.Value;
        }
    }
}