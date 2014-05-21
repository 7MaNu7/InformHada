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
        private FilmBiblio.UsuarioEN usuario = new FilmBiblio.UsuarioEN();
        private FilmBiblio.ComentarioEN comentarioEn = new FilmBiblio.ComentarioEN();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                BotonEditar.Visible = false;
                LiteralComentar.Visible = false;
                BotonComentar.Visible = false;
                TextBoxComentario.Visible = false;
                Rating1.Visible = false;
            }
            else
            {
                LiteralComentar.Text = "Deja tu comentario";
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
            {
                Rating1.CurrentRating = Convert.ToInt32(Math.Round(Convert.ToDecimal(pelicula.Puntuacion) / 2));
            }
            else
            {
                Rating1.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                comentario.Film = Convert.ToInt32( id);
                d = comentario.DameComentariosFilm(pelicula.Id);
                ListViewComentarios.DataSource = d;
                ListViewComentarios.DataBind();
            }
        }

        protected void ComentarOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            int id_pelicula = Convert.ToInt32(Request.QueryString["id"]);
            pelicula.Id = id_pelicula;
            pelicula = pelicula.DamePelicula();
            string texto = TextBoxComentario.Text;
            DateTime tomorrow = DateTime.Today.AddDays(0);

            comentarioEn.Usuario = usuario.Id;
            comentarioEn.Film = pelicula.Id;
            comentarioEn.Texto = texto;
            comentarioEn.Fecha = tomorrow.ToString();
            comentarioEn.InsertarComentario();
            Response.Redirect("Pelicula.aspx?id=" + pelicula.Id);
        }

        protected void OnRatingChanged(object sender, RatingEventArgs e)
        {
            if (usuario != null)
            {
                pelicula.AnyadirPuntuacionPelicula(usuario.Id, Convert.ToSingle(e.Value.ToString()) * 2);
                pelicula.DamePelicula();
                puntuacion.Text = pelicula.Puntuacion.ToString();
            }
        }

    }
}