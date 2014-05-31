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
            //mensaje cuando puntuas, inicialmente no se muestra
            Puntos.Visible = false;

            //la parte privada solo se ve cuando estas logeado
            if (Session["usuario"] == null)
            {
                BotonEditar.Visible = false;
                LiteralComentar.Visible = false;
                BotonComentar.Visible = false;
                TextBoxComentario.Visible = false;
                Rating1.Visible = false;
                Panelcomentar.Visible = false;
            }
            else
            {
                //si estas logeado tienes opcion a comentar
                LiteralComentar.Text = "Deja tu comentario";
                usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
               
            }
            //cogemos el id de la url
            String id = Request.QueryString["id"];

            //si no hay id volvemos a las peliculas
            if (id == null)
            {
                Response.Redirect("peliculas.aspx");
            }
            else     //si hay id
            {
                //editar te manda a editar esa peli en concreto
                BotonEditar.NavigateUrl = "AddEditPelicula.aspx?id="+id;
                BotonReport.NavigateUrl = "Report.aspx";

                pelicula.Id = Convert.ToInt32(id);
                pelicula = pelicula.DamePelicula();

                Page.Title = pelicula.Titulo;

                //se muestran los datos sacados de la bd y las imagenes de los directorios
                caratula.ImageUrl = "/img/film/caratula/"+pelicula.Id+".jpg";
                fondo.ImageUrl = "/img/film/portada/" + pelicula.Id + ".jpg";
                titulo.Text = pelicula.Titulo;

                musica.Text = pelicula.BandaSonora;
                genero.Text = pelicula.Genero;
                sinopsis.Text = pelicula.Sinopsis;
                director.Text = pelicula.Director;
                trailer.Text = pelicula.Trailer;
                puntuacion.Text = Convert.ToString( pelicula.Puntuacion);
                reparto.Text = Convert.ToString(pelicula.Reparto);
                ano.Text = Convert.ToString(pelicula.Ano);
                
            }
            if (usuario != null)
            {
                //si estas logeado puedes ver las estrellas de puntuar (y usarlas)
                imagen_user.ImageUrl = "/img/users/" + usuario.Id + ".jpg";
                Rating1.CurrentRating = Convert.ToInt32(Math.Round(Convert.ToDecimal(pelicula.Puntuacion) / 2));
            }
            else
            {
                //si no estas logeado no tienes acceso al sistema de puntuacion
                Rating1.Visible = false;
                Panelcomentar.Attributes.Add("CssClass","display:none;");
                Panelcomentar.CssClass = "comentar_oculto";
            }
            if (!Page.IsPostBack)
            {
                //mostrar los comentarios de la pelicula
                comentario.Film = Convert.ToInt32( id);
                d = comentario.DameComentariosFilm(pelicula.Id);
                ListViewComentarios.DataSource = d;
                ListViewComentarios.DataBind();
            }
        }
        //evento de comentar la pelicula
        protected void ComentarOnClick(object sender, EventArgs e)
        {
            usuario = (FilmBiblio.UsuarioEN)Session["usuario"];
            int id_pelicula = Convert.ToInt32(Request.QueryString["id"]);
            pelicula.Id = id_pelicula;
            pelicula = pelicula.DamePelicula();
            string texto = TextBoxComentario.Text;

            //fecha actual (momento en el que comentas)
            DateTime tomorrow = DateTime.Today.AddDays(0);

            //rellenamos el comentario con sus datos y se inserta
            comentarioEn.Usuario = usuario.Id;
            comentarioEn.Film = pelicula.Id;
            comentarioEn.Texto = texto;
            comentarioEn.Fecha = tomorrow.ToString();
            comentarioEn.InsertarComentario();

            //refrescar con comentario introducido
            Response.Redirect("Pelicula.aspx?id=" + pelicula.Id);
        }
        
        //evento al puntuar con las estrellas
        protected void OnRatingChanged(object sender, RatingEventArgs e)
        {
            //solo si estas logeado
            if (usuario != null)
            {
                int id_pelicula = Convert.ToInt32(Request.QueryString["id"]);
                pelicula.Id = id_pelicula;
                //se añade la puntuacion (o edita si ya ha puntuado), cada estrella vale 2 puntos
                pelicula.AnyadirPuntuacionPelicula(usuario.Id, Convert.ToSingle(e.Value.ToString()) * 2);
                
                //se vuelve a coger la pelicula con la puntuacion recalculada y se muestra
                pelicula.DamePelicula();
                puntuacion.Text = pelicula.Puntuacion.ToString();

                //no se puede hacer redirect desde este metodo
                Puntos.Visible = true;
                Puntos.Text = "Debe refrescar la página para ver la puntuación actualizada";
            }
        }

        //solo se muestra el boton eliminar de los comentarios si son tuyos
        protected void mostrar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int id_comentario = Convert.ToInt32(btn.ToolTip);
            if (usuario.Id != id_comentario)
                btn.Visible = false;
        }

        //al eliminar un comentario
        protected void Eliminarcomentario(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //se coge el id de la url
            int id_pelicula = Convert.ToInt32(Request.QueryString["id"]);

            //borramos el comentario del que se ha pulsado eliminar
            int id_comentario = Convert.ToInt32(btn.CommandArgument.ToString());
            comentario.BorrarComentario(id_comentario);

            //refrescamos con el comentario eliminado
            Response.Redirect("Pelicula.aspx?id=" + id_pelicula);
        }




    }
}